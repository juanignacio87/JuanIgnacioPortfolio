# ZimaBoard / ZimaOS: portfolio aislado

## Alcance y requisitos

Usar un proyecto Compose propio (`juanignacio-portfolio-zima`), sin combinar archivos
con `docker-compose.portfolio.yml`. No modificar el daemon, firewall global, redes o
contenedores existentes. No usar `prune`, `--remove-orphans`, `--privileged`, host networking
ni Docker Socket. Docker/Compose deben estar ya operativos en la ZimaBoard (Linux amd64).
El usuario administrador de Docker sigue siendo de confianza: este aislamiento no protege
frente a root o a quien controla el daemon. No ejecutar desde un directorio compartido por SMB.

`portfolio-web` solo pertenece a una red `internal: true`, sin puertos, volumenes,
secretos ni salida directa a Internet. Su DNS externo se desactiva con un resolver local
sin servicio. `cloudflared` es el unico miembro de esa red con una segunda red de salida;
no usa ninguna red existente. El unico archivo del host accesible a `cloudflared` es el
secreto Compose de solo lectura. Compose local implementa ese secreto mediante un bind mount,
no mediante almacenamiento cifrado de Swarm. Ambos servicios son no-root, read-only y sin
capacidades; `/tmp` de la app es un tmpfs limitado. Logs con rotacion local.

## Preparacion (en la ZimaBoard)

1. Clonar este repositorio en un directorio privado. Revisar sin modificar las redes existentes:

   ```sh
   docker network ls
   docker network inspect $(docker network ls -q) --format '{{.Name}} {{json .IPAM.Config}}'
   cp .env.zimaboard.example .env.zimaboard
   chmod 600 .env.zimaboard
   ```

   Completar hostname, URL HTTPS final y una etiqueta de imagen unica por release.
   Si `172.30.253.0/29` se superpone con otra red Docker/LAN, cambiar las tres variables
   de subred/IP juntas. No conectar ningun otro servicio a la red interna del portfolio.
   Las variables exportadas del shell prevalecen sobre `.env.zimaboard`: revisarlas tambien.

2. Crear un tunel **remotamente administrado** dedicado en Cloudflare. Configurar solo
   el hostname publico del portfolio con servicio `http://portfolio-web:8080` (HTTP interno,
   no HTTPS al origen). No publicar ZimaOS, SSH, Docker ni rutas privadas. Sin rutas comodin;
   las peticiones que no coincidan deben terminar en 404. Habilitar HTTPS obligatorio en
   el edge y WebSockets. No aplicar desafios/caches a `/_blazor` ni a `/_framework`.
   Confirmar que el Host que recibe el origen sea el hostname publico configurado.

3. Guardar el token directamente en el host, sin argumentos de comandos, historial o Git:

   ```sh
   install -d -m 700 secrets
   umask 077
   read -rsp 'Token del tunel: ' TUNNEL_SECRET; printf '\n'
   printf '%s' "$TUNNEL_SECRET" > secrets/cloudflared-token
   unset TUNNEL_SECRET
   sudo chown 65532:65532 secrets/cloudflared-token
   sudo chmod 400 secrets/cloudflared-token
   ```

   Ejecutar este bloque en **Bash**, sin `set -x`. Para Docker rootful de ZimaOS, el UID
   coincide con `cloudflared`. En rootless/userns-remap hay que ajustar el propietario al
   UID mapeado, no abrir permisos globales. Compose no garantiza aplicar uid/gid/mode a
   secretos basados en archivos: los permisos efectivos se establecen en el host.
   No guardar el token en `.env`, YAML, Dockerfile, tickets, capturas ni salidas de logs.
   No se entrega ni se crea un token real desde este proyecto.

## Desplegar

Desde la raiz del repositorio, definir un helper para que todos los comandos usen solo
este proyecto y el archivo explicito de entorno:

```sh
dc() { docker compose -p juanignacio-portfolio-zima --env-file .env.zimaboard -f docker-compose.zimaboard.yml "$@"; }
dc config --quiet
dc build --pull portfolio-web
dc pull cloudflared
dc up -d --no-build
dc ps
dc logs --tail=100 portfolio-web cloudflared
```

No abrir puertos en router/host. La app conserva el correo publico, LinkedIn, GitHub,
los cuatro PDF y `mailto` desde appsettings, sin copiarlos a secretos. No requiere
salidas HTTP del servidor. La imagen `cloudflare/cloudflared:2026.10.0` esta fijada;
revisar actualizaciones de seguridad y cambiar la version deliberadamente, idealmente
registrando tambien el digest obtenido al descargarla.

## Salud y verificacion obligatoria

```sh
dc exec -T portfolio-web bash -ec 'exec 3<>/dev/tcp/127.0.0.1/8080; printf "GET /health HTTP/1.1\r\nHost: localhost\r\nConnection: close\r\n\r\n" >&3; cat <&3'
docker inspect "$(dc ps -q portfolio-web)" --format '{{json .State.Health}}'
docker inspect "$(dc ps -q portfolio-web)" --format 'ports={{json .HostConfig.PortBindings}} mounts={{json .Mounts}} networks={{json .NetworkSettings.Networks}} user={{.Config.User}} readonly={{.HostConfig.ReadonlyRootfs}} caps={{json .HostConfig.CapDrop}} security={{json .HostConfig.SecurityOpt}}'
docker inspect "$(dc ps -q cloudflared)" --format 'ports={{json .HostConfig.PortBindings}} mounts={{json .Mounts}} networks={{json .NetworkSettings.Networks}} user={{.Config.User}}'
```

Esperar `/health` 200 `OK`, ningun puerto publicado, solo `/tmp` en RAM para la app
(sin montajes bind/volume), y solamente el secreto RO para cloudflared. La red interna
debe tener exactamente estos dos contenedores y `Internal=true`; la red de salida solo
cloudflared. Verificar con `docker network inspect` usando los nombres del inspect anterior.
Probar bloqueo de salida directa de la app sin agregar contenedores ni paquetes:

```sh
dc exec -T portfolio-web bash -ec 'if timeout 5 bash -c "exec 3<>/dev/tcp/1.1.1.1/443"; then echo "FALLO: salida inesperada"; exit 1; else echo "Sin salida TCP directa"; fi'
```

Finalmente, desde fuera de la LAN, abrir `https://TU_HOST/health`, `/`, cambiar ES/IT/EN/FR
y descargar cada PDF. En DevTools > Network > WS comprobar `/_blazor` con estado **101**
(HTTP/1.1) o CONNECT **200** (HTTP/2), con frames de datos,
y que el selector de idioma y la galeria sigan funcionando. Comprobar que no hay bucles
HTTPS y que canonical/og:image usan el dominio final. Si Cloudflare Access protege el sitio,
autenticarse primero para estas pruebas. Un healthcheck local correcto no valida el tunel.

ASP.NET procesa forwarded headers **antes** de HSTS y redireccion. Solo confia en la IP
exacta `PORTFOLIO_PROXY_IP`, con un salto; no en toda la subred, headers Host reenviados
ni cualquier origen. No activar `ASPNETCORE_FORWARDEDHEADERS_ENABLED=true`. Sin proxy
configurado no se habilita el middleware. `/health` acepta HTTP interno sin redireccion.
Las claves Data Protection son efimeras para no montar almacenamiento: tras reinicio se
invalidan cookies antiforgery antiguas y los usuarios deben recargar; Blazor no conserva
circuitos entre reinicios. Nunca escalar replicas sin revisar afinidad/estado/claves.

## Actualizar y volver atras

Antes de actualizar, guardar el hash Git actual y la etiqueta anterior de imagen (sin
incluir secretos en la copia), y conservar esa imagen local. No reutilizar etiquetas:

```sh
git rev-parse HEAD
dc images
git pull --ff-only
# Editar solo PORTFOLIO_IMAGE_TAG en .env.zimaboard con una etiqueta nueva.
dc build --pull portfolio-web
dc up -d --no-build portfolio-web
dc ps
```

Si se actualiza la version fijada de cloudflared: `dc pull cloudflared` y
`dc up -d --no-build cloudflared`. Repetir salud, descargas y WS despues de cada cambio.
Para rollback, restaurar la revision anterior del archivo Compose si cambio, poner la
etiqueta anterior en `.env.zimaboard` y ejecutar `dc up -d --no-build --pull never`.
Conservar tambien la imagen anterior de cloudflared si se actualiza; volver al tag/digest
anterior en Compose antes de recrearlo. No hacer `git reset --hard`, eliminar imagenes
ni tocar los otros proyectos. El rollback corta circuitos Blazor: recargar navegador.

## Retirada inmediata ante un incidente

```sh
dc stop -t 0 cloudflared
```

Esto corta el conector de este proyecto sin afectar otros contenedores. Si no responde,
usar `dc kill cloudflared` y luego `dc stop portfolio-web`. Desde Cloudflare, deshabilitar
el hostname/tunel y **rotar o revocar su token** (retirar el DNS solo no revoca credenciales).
Si hay replicas de este tunel en otros equipos, deshabilitarlas tambien desde el panel.
No reiniciar ni volver a publicar antes de revisar causa, logs y credenciales. Conservar
evidencia de forma privada; no publicar el secreto. No detener Docker globalmente.

## Limitaciones y fuentes

- La validacion real de imagen, sandbox Linux, egress y tunel requiere Docker activo y
  un token/dominio real en la ZimaBoard; el proyecto no los crea automaticamente.
- El portfolio utiliza .NET 10 LTS estable, con soporte hasta el **14 de noviembre de 2028**.
  Mantener al dia los parches de las imagenes SDK y ASP.NET mediante builds con `--pull`.
- [Cloudflare: token-file y parametros](https://developers.cloudflare.com/tunnel/reference/run-parameters/)
- [Imagen oficial cloudflared no-root](https://github.com/cloudflare/cloudflared/blob/2026.10.0/Dockerfile)
- [Docker: redes internas](https://docs.docker.com/reference/compose-file/networks/)
- [Docker: secretos locales](https://docs.docker.com/compose/how-tos/use-secrets/)
- [ASP.NET: proxies de confianza](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer)
- [Ciclo de soporte .NET](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)
