# Campo tecnologico

Rediseño del portfolio independiente. Blazor Server, .NET 8, sin frameworks de UI.
No modifica CattleCat, RegionalLeagueApp ni las copias anteriores.

## Contenido

Todos los textos ES/IT/EN/FR estan en `Services/PortfolioContentService.cs`.
El selector sigue ese orden y recuerda la seleccion. Italiano incluye contenido,
metadatos (`it_IT`), mensajes de error y accesibilidad. Se conservan los nombres
CattleCat, RegionalLeagueApp y NodoAgrícola; los titulos descriptivos se localizan.
No hay URLs separadas por idioma: el sitemap mantiene una sola entrada.
Los niveles de idiomas corresponden a los datos proporcionados por el titular.
No se inventaron fechas, instituciones, resultados de proyectos ni capturas.
Confirmar los estados de los proyectos secundarios antes de publicar.
Los componentes anteriores que ya no se muestran se conservan para referencia.

## Contacto y CV

Completar `Portfolio__Email`, `Portfolio__LinkedInUrl`, `Portfolio__GitHubUrl`,
`Portfolio__PublicUrl` y `Portfolio__CvUrl`, o sus equivalentes `PORTFOLIO_*`
en Compose. No se creo ningun .env real.
Los contactos vacios permanecen ocultos hasta configurarse, sin enlaces ficticios.
El boton de CV dirige al aviso pendiente hasta configurar un archivo final.
Guardar el PDF real en `wwwroot/cv/` y configurar la ruta relativa.
El contacto usa enlaces directos, sin formulario visual que prometa un envio.
Los modos de formulario anteriores se conservan en configuracion para una futura integracion.

## Capturas reales de CattleCat

Guardar imagenes anonimizadas en `wwwroot/images/projects/cattlecat/`.
Configurar `Portfolio:CattleCatScreenshots` en appsettings o variables de entorno:

```json
"CattleCatScreenshots": [
  {
    "Url": "images/projects/cattlecat/inventario.png",
    "Alt": {
      "es": "CattleCat: inventario por establecimiento y categoria",
      "it": "CattleCat: consistenze per azienda agricola e categoria",
      "en": "CattleCat: inventory by farm and category",
      "fr": "CattleCat : stock par exploitation et categorie"
    }
  }
]
```

No agregar esa entrada hasta que exista el archivo. Cada imagen se abre en tamaño
completo; incluir textos alternativos en los cuatro idiomas. Quitar nombres de
usuarios, establecimientos, rutas de disco y datos productivos privados.
En Docker puede configurarse `Portfolio__CattleCatScreenshots__0__Url` y
`Portfolio__CattleCatScreenshots__0__Alt__es` (tambien `it`, `en` y `fr`).
Si falta un texto alternativo, se muestra el nombre CattleCat en lugar de
mezclar una descripcion de otro idioma. Agregar siempre las cuatro traducciones.
Los otros proyectos conservan soporte ImageUrl, ImageAlt, ProjectUrl y RepositoryUrl.

## Assets y SEO

La fotografia de campos `field-hero.jpg` es una composicion original generada
para este portfolio: no representa una explotacion del titular ni una captura
de producto. No contiene marcas de terceros. Iconos Lucide (ISC), fuente
Manrope (OFL), alojados localmente con sus licencias. No hay peticiones externas
de fuentes o iconos al visitar la pagina.
Open Graph usa `images/social-preview.png`: PNG para compatibilidad con redes.
Su fuente editable es `images/social-preview-v2.svg`; `social-preview.svg` conserva
la misma version neutral: Juan Ignacio Bastonero / Agribusiness · Software · Agro 4.0.
Configurar PublicUrl con el dominio HTTPS final, sin query ni fragmento.
Canonical, robots y sitemap utilizan esa base. Sin PublicUrl se usa la URL local.

## Verificacion y publicacion

```powershell
dotnet build JuanIgnacioPortfolio.sln -c Release
dotnet publish JuanIgnacio.Portfolio.Web -c Release -o artifacts/publish
dotnet run --project JuanIgnacio.Portfolio.Web --launch-profile http
docker compose -f docker-compose.portfolio.yml --env-file JuanIgnacio.Portfolio.Web/.env up -d --build
```

Antes de publicar: contacto real, CV PDF, capturas, confirmar proyectos y trayectoria,
dominio/PublicUrl, HTTPS, Docker activo y comprobar ES/IT/EN/FR en movil y escritorio.
No publicar telefono ni direccion personal. El idioma se recuerda en almacenamiento
local opcional; no se realiza traduccion automatica.

## Archivos de esta propuesta

Modificados dentro de `JuanIgnacio.Portfolio.Web/`:
- `Components/App.razor`, `Components/Layout/MainLayout.razor`, `Components/Pages/Home.razor`.
- `Components/Sections/SiteHeader.razor`, `HeroSection.razor`, `AboutSection.razor`,
  `ProjectsSection.razor`, `ExperienceSection.razor`, `SkillsSection.razor`, `ContactSection.razor`.
- `Models/PortfolioContent.cs`, `Models/SiteOptions.cs`, `Services/PortfolioContentService.cs`.
- `wwwroot/app.css`, `Program.cs`, `appsettings.json`, `appsettings.Development.json`, `appsettings.Production.json`.
- `.env.example`, `.env.production.example`, `README.md`.

Nuevos dentro de `JuanIgnacio.Portfolio.Web/`:
- `Components/Sections/CvLink.razor`, `Icon.razor`, `ProfessionalLink.razor`, `ProjectCard.razor`, `TechBadges.razor`.
- `wwwroot/portfolio.js`, `wwwroot/fonts/manrope.ttf`, `wwwroot/fonts/OFL.txt`.
- `wwwroot/images/field-hero.jpg`, `lucide-sprite.svg`, `lucide-LICENSE.txt`,
  `social-preview-v2.svg`, `social-preview.png`, `projects/cattlecat/.gitkeep`.

Raiz: modificados `README.md`, `docker-compose.portfolio.yml`; nuevo `REDESIGN-NOTES.md`.
Ningun archivo eliminado. No se hicieron commit, push ni cambios en otros proyectos.
