# Juan Ignacio Portfolio

## Propuesta visual Campo tecnologico

Ver [guia del rediseño](REDESIGN-NOTES.md) para contenido, capturas reales,
contactos, CV, assets y checklist actualizado. El nuevo contacto usa enlaces
directos, no el formulario de demostracion descrito en la documentacion historica.
Los contactos no configurados y el CV provisional se indican como pendientes.
La imagen social por defecto ahora es `images/social-preview.png` (fuente SVG v2).

Landing personal desarrollada con Blazor Server en .NET 8.

## Ejecutar en local

Desde la raiz del workspace:

```powershell
dotnet run --project JuanIgnacio.Portfolio.Web --launch-profile http
```

URL local por defecto:

```text
http://localhost:5100
```

## Configuracion

La configuracion publica del portfolio vive bajo la seccion `Portfolio` de `appsettings*.json` y puede sobrescribirse con variables de entorno.

Variables soportadas:

```text
Portfolio__Email
Portfolio__LinkedInUrl
Portfolio__GitHubUrl
Portfolio__CvUrl
Portfolio__PublicUrl
Portfolio__SocialImageUrl
Portfolio__ContactFormMode
Portfolio__ContactApiUrl
Portfolio__FormspreeUrl
```

Para Docker/Compose se incluyen variables `PORTFOLIO_*` en `.env.example` y `.env.production.example`.

Modos previstos para el formulario:

- `mailto`: estrategia actual, abre el cliente de email si `Portfolio__Email` esta configurado.
- `api`: preparado para enviar por POST a `Portfolio__ContactApiUrl`.
- `formspree`: preparado para enviar por POST a `Portfolio__FormspreeUrl`.

## Build y publish

```powershell
dotnet build JuanIgnacio.Portfolio.Web\JuanIgnacio.Portfolio.Web.csproj
dotnet publish JuanIgnacio.Portfolio.Web\JuanIgnacio.Portfolio.Web.csproj -c Release -o .\artifacts\portfolio-publish
```

El resultado publicable queda en:

```text
artifacts/portfolio-publish
```

Para ejecutar el publish localmente:

```powershell
dotnet .\artifacts\portfolio-publish\JuanIgnacio.Portfolio.Web.dll --urls http://localhost:8088
```

## Docker

Build de imagen desde la raiz del repo:

```powershell
docker build -f JuanIgnacio.Portfolio.Web\Dockerfile -t juanignacio-portfolio:local .
```

Run directo:

```powershell
docker run --rm -p 8088:8080 --env-file JuanIgnacio.Portfolio.Web\.env.example juanignacio-portfolio:local
```

URL:

```text
http://localhost:8088
```

## Docker Compose

Levanta solo la landing, sin RegionalLeagueApp:

```powershell
docker compose --env-file JuanIgnacio.Portfolio.Web\.env.example -f docker-compose.portfolio.yml up --build
```

En produccion conviene copiar `.env.example` a un archivo propio no versionado y completar:

```text
PORTFOLIO_HTTP_PORT=
PORTFOLIO_EMAIL=
PORTFOLIO_LINKEDIN_URL=
PORTFOLIO_GITHUB_URL=
PORTFOLIO_CV_URL=
PORTFOLIO_PUBLIC_URL=
PORTFOLIO_SOCIAL_IMAGE_URL=
PORTFOLIO_CONTACT_FORM_MODE=
PORTFOLIO_CONTACT_API_URL=
PORTFOLIO_FORMSPREE_URL=
```

Tambien puedes partir de `JuanIgnacio.Portfolio.Web/.env.production.example`, que contiene placeholders ficticios y puede versionarse.

## Como agregar capturas reales de proyectos

Las imagenes de portfolio viven en:

```text
JuanIgnacio.Portfolio.Web/wwwroot/images/projects/
```

Formato recomendado:

- `webp`, `jpg`, `png` o `svg`.
- Relacion 16:9, por ejemplo `1200x675`.
- Peso optimizado para web.
- Nombre descriptivo, por ejemplo `cattlecat-dashboard.webp`.

Para usar una captura real, colocar el archivo en esa carpeta y actualizar el proyecto correspondiente en `Services/PortfolioContentService.cs`:

```csharp
ImageUrl: "images/projects/cattlecat-dashboard.webp",
ImageAlt: "Dashboard de inventario ganadero de CattleCat",
ProjectUrl: "https://demo.example.com",
RepositoryUrl: "https://github.com/usuario/repositorio"
```

`ProjectUrl` y `RepositoryUrl` son opcionales. Si estan vacios, los botones no se muestran. Si `ImageUrl` esta vacio, la card muestra un placeholder visual elegante.

## SEO y social sharing

Los textos SEO por idioma se editan en `Services/PortfolioContentService.cs`, dentro de `SeoContent`:

```csharp
new SeoContent(
    "Titulo de la pagina",
    "Descripcion para buscadores",
    "keywords, separadas, por coma",
    "Autor",
    "Titulo social",
    "Descripcion social")
```

La URL canonical, `og:url`, `robots.txt` y `sitemap.xml` usan:

```text
Portfolio__PublicUrl
```

En produccion debe ser la URL final del sitio, por ejemplo:

```text
Portfolio__PublicUrl=https://juanignacio.dev
```

La imagen social por defecto es:

```text
wwwroot/images/social-preview.svg
```

Para cambiarla:

1. Reemplazar `wwwroot/images/social-preview.svg`, o agregar otra imagen optimizada.
2. Configurar `Portfolio__SocialImageUrl`, por ejemplo:

```text
Portfolio__SocialImageUrl=images/social-preview.png
```

Tambien se incluye `wwwroot/favicon.svg`. Si se reemplaza el favicon, mantener el mismo nombre o actualizar el `<link rel="icon">` en `Components/App.razor`.

`wwwroot/robots.txt` y `wwwroot/sitemap.xml` quedan como plantillas estaticas. Cuando la app corre en ASP.NET, `Program.cs` genera respuestas dinamicas para `/robots.txt` y `/sitemap.xml` usando `Portfolio__PublicUrl`.

## Deploy en VPS / servidor propio

Opcion sin Docker:

1. Ejecutar `dotnet publish`.
2. Copiar `artifacts/portfolio-publish` al servidor.
3. Instalar ASP.NET Core Runtime 8.
4. Ejecutar la app con `ASPNETCORE_URLS=http://127.0.0.1:8088`.
5. Poner Nginx/Caddy/Traefik como reverse proxy con HTTPS.
6. Configurar variables `Portfolio__...` en el servicio systemd o entorno del host.

Opcion recomendada con Docker:

1. Construir o subir la imagen.
2. Ejecutar `docker compose -f docker-compose.portfolio.yml up -d`.
3. Exponer el contenedor detras de Nginx Proxy Manager, Caddy, Traefik o Cloudflare Tunnel.

## ZimaBoard / ZimaOS

Ruta simple:

1. Instalar Docker/Compose o usar la app de contenedores de ZimaOS.
2. Copiar este repo o solo `docker-compose.portfolio.yml`, `JuanIgnacio.Portfolio.Web/Dockerfile` y la carpeta del proyecto.
3. Crear un `.env` real con las variables `PORTFOLIO_*`.
4. Ejecutar:

```bash
docker compose --env-file .env -f docker-compose.portfolio.yml up -d --build
```

5. Publicar con una de estas opciones:
   - Reverse proxy local hacia `http://localhost:8088`.
   - Cloudflare Tunnel.
   - Redireccion de puertos del router con HTTPS en proxy.

## GitHub Pages

Esta app es Blazor Server, por lo que necesita un proceso .NET ejecutandose. GitHub Pages solo sirve archivos estaticos, asi que no es un destino directo para esta version.

Opciones si se quiere GitHub Pages:

- Convertir la landing a Blazor WebAssembly estatico.
- Generar una version HTML/CSS estatica del portfolio.
- Mantener Blazor Server para VPS/Docker/ZimaBoard y usar GitHub Pages solo para una pagina estatica alternativa.

## Estructura

- `Components/Pages/Home.razor`: composicion de la landing.
- `Components/Sections`: secciones reutilizables.
- `Models/PortfolioContent.cs`: contratos del contenido.
- `Models/SiteOptions.cs`: opciones configurables por entorno.
- `Services/PortfolioContentService.cs`: textos ES/EN/FR y datos editables.
- `wwwroot/app.css`: estilos responsive.
- `wwwroot/cv/Juan-Ignacio-CV.html`: CV descargable temporal, preparado para reemplazar por PDF.
- `wwwroot/images/projects/`: placeholders y futuras capturas reales de proyectos.
- `wwwroot/images/social-preview.svg`: imagen por defecto para Open Graph y Twitter/X cards.
- `wwwroot/favicon.svg`: favicon principal.
- `wwwroot/robots.txt` y `wwwroot/sitemap.xml`: plantillas estaticas; la app genera versiones dinamicas con `PublicUrl`.
- `Dockerfile`: build y runtime de la landing.
- `.env.example`: variables de despliegue para Docker/Compose.
- `.env.production.example`: plantilla de produccion con valores ficticios versionables.

## Pendiente antes de publicar

- Completar email, LinkedIn, GitHub y URL publica reales.
- Reemplazar `wwwroot/cv/Juan-Ignacio-CV.html` por el PDF final.
- Elegir estrategia de contacto: `mailto`, API propia o servicio externo.
- Agregar dominio y HTTPS en VPS/ZimaBoard.
- Agregar capturas, enlaces reales o repositorios a cada proyecto.

## Checklist de publicacion

- Colocar email real en `Portfolio__Email` o `PORTFOLIO_EMAIL`.
- Colocar LinkedIn real en `Portfolio__LinkedInUrl` o `PORTFOLIO_LINKEDIN_URL`.
- Colocar GitHub real en `Portfolio__GitHubUrl` o `PORTFOLIO_GITHUB_URL`.
- Reemplazar el CV temporal por el PDF final y ajustar `Portfolio__CvUrl` si cambia el nombre.
- Reemplazar placeholders por screenshots reales en `wwwroot/images/projects/`.
- Definir dominio final.
- Configurar `Portfolio__PublicUrl` con la URL publica definitiva.
- Probar Docker con el daemon activo: `docker build -f JuanIgnacio.Portfolio.Web\Dockerfile -t juanignacio-portfolio:local .`.
- Probar compose: `docker compose --env-file JuanIgnacio.Portfolio.Web\.env.example -f docker-compose.portfolio.yml up --build`.
- Revisar SEO social en una herramienta de preview antes de compartir.
- Publicar.
