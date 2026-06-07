using JuanIgnacio.Portfolio.Web.Models;

namespace JuanIgnacio.Portfolio.Web.Services;

public sealed class PortfolioContentService
{
    private const string CattleCatImage = "images/projects/cattlecat.svg";
    private const string RegionalLeagueImage = "images/projects/regional-league-app.svg";
    private const string ZimaBoardImage = "images/projects/zimaboard-home-server.svg";
    private const string RobotImage = "images/projects/agricultural-robot.svg";
    private const string EcommerceImage = "images/projects/bidets-ecommerce.svg";

    public IReadOnlyList<LanguageOption> Languages { get; } =
    [
        new("es", "ES", "Español"),
        new("en", "EN", "English"),
        new("fr", "FR", "Français")
    ];

    public PortfolioContent Get(string languageCode)
    {
        var normalizedCode = Languages.Any(language => language.Code == languageCode)
            ? languageCode
            : "es";

        return normalizedCode switch
        {
            "en" => English,
            "fr" => French,
            _ => Spanish
        };
    }

    private static PortfolioContent Spanish => new(
        "es",
        new(
            "Juan Ignacio | Agrotech, Software, IoT y Datos",
            "Portfolio profesional de Juan Ignacio: perfil híbrido en Agrotech, software C#/.NET, IoT agrícola, datos, automatización y proyectos aplicados al sector agroalimentario.",
            "Juan Ignacio, Agrotech, Agro 4.0, software para agro, C#, .NET, Blazor, IoT agrícola, machine learning, Python, automatización agrícola, portfolio",
            "Juan Ignacio",
            "Juan Ignacio | Agrotech, Software e IoT",
            "Portfolio profesional sobre Agrotech, software, IoT, datos y automatización aplicada al campo."),
        new("Sobre mí", "Objetivo", "Áreas", "Proyectos", "Experiencia", "Skills", "CV", "Contacto"),
        new(
            "Juan Ignacio",
            "Agrotecnología, software e innovación aplicada al campo.",
            "Agrotech · Software · IoT · Datos",
            "Perfil híbrido entre agronegocios, agroalimentos y tecnología. Diseño y construyo soluciones con C#/.NET, Python, sensores, datos y automatización para llevar decisiones más precisas al entorno agroalimentario.",
            ["Agrotech", "Backend .NET", "IoT agrícola", "Datos y dashboards", "Automatización", "Perfil internacional"],
            new("Ver proyectos", "Descargar CV", "Contactar")),
        "Sobre mí",
        "Combino formación en Agronegocios y Gestión de Agroalimentos con desarrollo de software, IoT y tecnología aplicada al campo. Me interesa trabajar cerca de problemas reales: inventarios ganaderos, trazabilidad, captura de datos, tableros operativos, automatización y herramientas que ayuden a productores, equipos técnicos y empresas agroalimentarias a decidir mejor.",
        new(
            "Objetivo profesional",
            "Busco oportunidades en Agrotech, Agro 4.0, software aplicado al agro, IoT agrícola, datos y automatización. Me motivan especialmente las empresas tecnológicas vinculadas al sector agroalimentario, donde pueda aportar una mirada que entiende tanto el negocio productivo como la construcción técnica de soluciones.",
            ["Agrotech", "Agro 4.0", "Software para agro", "IoT agrícola", "Datos", "Automatización", "Sector agroalimentario"]),
        "Áreas de interés",
        [
            new("Agrotech / Agro 4.0", "Digitalización de procesos productivos, trazabilidad, monitoreo y herramientas para decisiones operativas."),
            new("Backend C# / .NET", "APIs, servicios, lógica de negocio, persistencia y arquitectura mantenible para productos reales."),
            new("IoT y sensores", "Captura de variables de campo, telemetría, hardware edge y conexión entre dispositivos y software."),
            new("Machine Learning aplicado al agro", "Modelos en Python para explorar patrones, clasificar datos y apoyar predicción en contextos productivos."),
            new("Automatización agrícola", "Prototipos y flujos que reduzcan tareas manuales, mejoren precisión y permitan operar con datos."),
            new("Data / dashboards", "Visualización clara de inventarios, indicadores, alertas, evolución productiva y estado de sistemas."),
            new("Raspberry Pi / ZimaBoard", "Infraestructura propia para laboratorio, servidores, telemetría, almacenamiento y pruebas de campo.")
        ],
        "Proyectos",
        "Casos de portfolio orientados a resolver problemas concretos con software, datos e infraestructura ligera.",
        new("Problema", "Tecnologías", "Rol", "Estado", "Próximo paso", "Ver proyecto", "Ver repositorio", "Captura del proyecto próximamente"),
        [
            new(
                "CattleCat / inventario ganadero",
                "Sistema de escritorio para ordenar animales, lotes, movimientos y datos productivos de un establecimiento ganadero.",
                "La información ganadera suele dispersarse entre planillas, papel y memoria operativa, dificultando trazabilidad, control de stock y toma de decisiones.",
                ["C#", "WPF", "SQL Server", "Entity Framework"],
                "Diseño funcional, modelado de datos, interfaz de escritorio y lógica de gestión.",
                "Funcional",
                "Preparar reportes, exportación de datos y una posible versión web o mobile.",
                "Ver más",
                ImageUrl: CattleCatImage,
                ImageAlt: "Placeholder visual de CattleCat con paneles de inventario ganadero"),
            new(
                "Regional League App",
                "Plataforma web para administrar ligas regionales, clubes, fixtures, resultados, tablas, goleadores y colaboradores.",
                "Las competencias locales necesitan una herramienta simple para publicar información confiable y coordinar carga de resultados sin depender de procesos manuales.",
                ["Blazor", ".NET", "PostgreSQL", "Docker", "SignalR"],
                "Arquitectura, backend, UI Blazor, modelo de dominio, despliegue y módulos administrativos.",
                "En desarrollo",
                "Pulir experiencia pública, permisos por colaborador y flujo de carga en vivo.",
                "Ver más",
                ImageUrl: RegionalLeagueImage,
                ImageAlt: "Placeholder visual de Regional League App con tablero de resultados"),
            new(
                "ZimaBoard home server / laboratorio de telemetría",
                "Servidor casero para experimentar con servicios, almacenamiento, backups, telemetría y despliegues livianos.",
                "Los proyectos IoT y de datos necesitan un entorno estable para probar servicios, recibir mediciones y simular infraestructura edge antes de llevarla a campo.",
                ["ZimaBoard", "Linux", "Docker", "IoT", "Networking"],
                "Instalación, configuración de servicios, pruebas de infraestructura y documentación del laboratorio.",
                "Prototipo",
                "Integrar dashboards de sensores y pipelines de datos agro.",
                "Ver más",
                ImageUrl: ZimaBoardImage,
                ImageAlt: "Placeholder visual de ZimaBoard Home Server y telemetría"),
            new(
                "Prototipo de robot agrícola autónomo",
                "Exploración de un robot a pequeña escala para navegación, sensado y automatización de tareas agrícolas.",
                "Muchas tareas repetitivas del campo pueden beneficiarse de robots pequeños, económicos y modulares para inspección, monitoreo o asistencia.",
                ["Raspberry Pi", "Python", "Sensores", "Visión", "Control"],
                "Concepto técnico, selección de hardware, experimentos de sensores y arquitectura inicial.",
                "Idea avanzada",
                "Construir MVP con chasis, lectura de sensores y navegación básica.",
                "Ver más",
                ImageUrl: RobotImage,
                ImageAlt: "Placeholder visual de robot agrícola autónomo con sensores"),
            new(
                "Landing ecommerce multilingüe para bidets",
                "Landing comercial multilingüe para presentar productos de baño/bidets a públicos internacionales.",
                "Un producto físico orientado a diferentes mercados necesita comunicar valor, confianza y beneficios con contenido localizado.",
                ["HTML", "CSS", "JavaScript", "SEO", "i18n"],
                "Estructura de landing, copy multilingüe, diseño responsive y base SEO.",
                "Prototipo",
                "Conectar catálogo, analítica y formulario comercial real.",
                "Ver más",
                ImageUrl: EcommerceImage,
                ImageAlt: "Placeholder visual de landing ecommerce multilingüe para bidets")
        ],
        "Experiencia y formación",
        [
            new("Técnico en Agronegocios", "Base técnica en producción, gestión, comercialización y funcionamiento de cadenas agroalimentarias."),
            new("Licenciatura en Gestión de Agroalimentos", "Formación universitaria avanzada con enfoque en gestión, calidad, procesos y visión sistémica del sector agroalimentario. Tesis pendiente."),
            new("Agrotecnología / Agro 4.0", "Formación actual orientada a digitalización, sensores, datos, automatización e innovación aplicada al campo."),
            new("Desarrollo backend C#/.NET", "Práctica con Blazor, APIs, SQL, arquitectura por capas, autenticación, Docker y despliegue."),
            new("IoT y machine learning con Python", "Exploración de telemetría, procesamiento de datos, prototipos con hardware y modelos aplicados a problemas agro."),
            new("Experiencia internacional y atención al cliente", "Comunicación intercultural, ventas, adaptabilidad y trato directo con personas en entornos exigentes.")
        ],
        "Skills",
        [
            new("Agro / Agroalimentos", ["Agronegocios", "Gestión agroalimentaria", "Trazabilidad", "Producción ganadera", "Agro 4.0"]),
            new("Software", ["C#", ".NET", "Blazor", "WPF", "SQL", "Docker", "Git"]),
            new("Datos", ["Python", "Machine learning", "Dashboards", "Análisis exploratorio", "Modelado de datos"]),
            new("IoT / hardware", ["Raspberry Pi", "ZimaBoard", "Sensores", "Telemetría", "Linux"]),
            new("Idiomas", ["Español", "Inglés", "Francés", "Italiano"])
        ],
        new(
            "CV descargable",
            "Bloque preparado para publicar el CV final. Por ahora descarga una versión HTML resumida; luego se puede reemplazar el archivo por un PDF manteniendo el mismo botón.",
            "Descargar CV",
            "Preparado para PDF, versión ATS y enlaces profesionales.",
            ["Perfil Agrotech / Software", "Formación", "Proyectos", "Skills", "Idiomas"]),
        new(
            "Disponible para",
            "Colaboraciones y oportunidades donde el conocimiento agro se combine con construcción técnica real.",
            ["Oportunidades Agrotech", "Proyectos IoT", "Backend .NET", "Automatización agrícola", "Colaboración técnica", "Prácticas / junior-mid tech-agro"]),
        "Contacto",
        new(
            "Abierto a oportunidades laborales, colaboraciones técnicas y proyectos donde software, datos e infraestructura ayuden a mejorar decisiones en el campo.",
            "Nombre",
            "Email",
            "Mensaje",
            "Enviar",
            "Email",
            "LinkedIn",
            "GitHub",
            "CV descargable",
            "Formulario visual preparado para conectar con un backend o servicio externo."),
        "Juan Ignacio · Agrotech, software e innovación aplicada al agro.");

    private static PortfolioContent English => Spanish with
    {
        LanguageCode = "en",
        Seo = new(
            "Juan Ignacio | Agrotech, Software, IoT and Data",
            "Professional portfolio of Juan Ignacio: a hybrid Agrotech profile working with C#/.NET software, agricultural IoT, data, automation and agrifood projects.",
            "Juan Ignacio, Agrotech, Agriculture 4.0, agricultural software, C#, .NET, Blazor, agricultural IoT, machine learning, Python, agricultural automation, portfolio",
            "Juan Ignacio",
            "Juan Ignacio | Agrotech, Software and IoT",
            "Professional portfolio focused on Agrotech, software, IoT, data and automation applied to agriculture."),
        Nav = new("About", "Goal", "Interests", "Projects", "Experience", "Skills", "CV", "Contact"),
        Hero = new(
            "Juan Ignacio",
            "Agrotechnology, software and innovation applied to agriculture.",
            "Agrotech · Software · IoT · Data",
            "A hybrid profile connecting agribusiness, agrifood systems and technology. I design and build solutions with C#/.NET, Python, sensors, data and automation to bring better decision-making into agricultural operations.",
            ["Agrotech", "Backend .NET", "Agricultural IoT", "Data & dashboards", "Automation", "International profile"],
            new("View projects", "Download CV", "Contact")),
        AboutTitle = "About me",
        AboutText = "I combine a background in Agribusiness and Agrifood Management with software development, IoT and technology applied to agriculture. I like working close to real operational problems: livestock inventories, traceability, data capture, dashboards, automation and tools that help producers, technical teams and agrifood companies make better decisions.",
        ProfessionalGoal = new(
            "Professional goal",
            "I am looking for opportunities in Agrotech, Agriculture 4.0, software for agriculture, agricultural IoT, data and automation. I am especially interested in technology companies connected to the agrifood sector, where I can contribute both domain understanding and hands-on technical execution.",
            ["Agrotech", "Agriculture 4.0", "Agricultural software", "Agricultural IoT", "Data", "Automation", "Agrifood sector"]),
        InterestsTitle = "Areas of interest",
        Interests =
        [
            new("Agrotech / Agriculture 4.0", "Digital production workflows, traceability, monitoring and tools for operational decisions."),
            new("Backend C# / .NET", "APIs, services, business logic, persistence and maintainable architecture for real products."),
            new("IoT and sensors", "Field-variable capture, telemetry, edge hardware and the connection between devices and software."),
            new("Machine Learning for agriculture", "Python models to explore patterns, classify data and support prediction in production contexts."),
            new("Agricultural automation", "Prototypes and workflows that reduce manual work, improve precision and enable data-driven operations."),
            new("Data / dashboards", "Clear visualization of inventories, indicators, alerts, production trends and system status."),
            new("Raspberry Pi / ZimaBoard", "Personal infrastructure for labs, servers, telemetry, storage and field-oriented testing.")
        ],
        ProjectsTitle = "Projects",
        ProjectsIntro = "Portfolio cases focused on solving concrete problems with software, data and lightweight infrastructure.",
        ProjectLabels = new("Problem", "Technologies", "Role", "Status", "Next step", "View project", "View repository", "Project preview coming soon"),
        Projects =
        [
            new("CattleCat / livestock inventory", "Desktop system for managing animals, batches, movements and productive farm data.", "Livestock information is often scattered across spreadsheets, paper and operational memory, making traceability, stock control and decision-making harder.", ["C#", "WPF", "SQL Server", "Entity Framework"], "Functional design, data modeling, desktop UI and management logic.", "Functional", "Add reports, data export and a possible web or mobile version.", "View more", ImageUrl: CattleCatImage, ImageAlt: "Visual placeholder for CattleCat with livestock inventory panels"),
            new("Regional League App", "Web platform to manage regional leagues, clubs, fixtures, results, standings, scorers and contributors.", "Local competitions need a simple tool to publish reliable information and coordinate result entry without manual bottlenecks.", ["Blazor", ".NET", "PostgreSQL", "Docker", "SignalR"], "Architecture, backend, Blazor UI, domain model, deployment and administration modules.", "In development", "Improve the public experience, contributor permissions and live result workflows.", "View more", ImageUrl: RegionalLeagueImage, ImageAlt: "Visual placeholder for Regional League App with results dashboard"),
            new("ZimaBoard home server / telemetry lab", "Home server for experimenting with services, storage, backups, telemetry and lightweight deployments.", "IoT and data projects need a stable environment to test services, receive measurements and simulate edge infrastructure before field use.", ["ZimaBoard", "Linux", "Docker", "IoT", "Networking"], "Installation, service configuration, infrastructure tests and lab documentation.", "Prototype", "Integrate sensor dashboards and agricultural data pipelines.", "View more", ImageUrl: ZimaBoardImage, ImageAlt: "Visual placeholder for ZimaBoard Home Server and telemetry lab"),
            new("Autonomous agricultural robot prototype", "Small-scale exploration of navigation, sensing and agricultural task automation.", "Many repetitive field tasks could benefit from small, affordable and modular robots for inspection, monitoring or assistance.", ["Raspberry Pi", "Python", "Sensors", "Vision", "Control"], "Technical concept, hardware selection, sensor experiments and initial architecture.", "Advanced idea", "Build an MVP with chassis, sensor readings and basic navigation.", "View more", ImageUrl: RobotImage, ImageAlt: "Visual placeholder for an autonomous agricultural robot with sensors"),
            new("Multilingual ecommerce landing for bidets", "Commercial landing page to present bathroom and bidet products to international audiences.", "A physical product aimed at different markets needs to communicate value, trust and benefits with localized content.", ["HTML", "CSS", "JavaScript", "SEO", "i18n"], "Landing structure, multilingual copy, responsive design and SEO foundation.", "Prototype", "Connect a catalog, analytics and a real commercial form.", "View more", ImageUrl: EcommerceImage, ImageAlt: "Visual placeholder for a multilingual ecommerce landing for bidets")
        ],
        ExperienceTitle = "Experience and education",
        Experience =
        [
            new("Agribusiness technician", "Technical foundation in production, management, commercialization and agrifood value chains."),
            new("Degree in Agrifood Management", "Advanced university education focused on management, quality, processes and a systemic view of the agrifood sector. Thesis pending."),
            new("Agrotechnology / Agriculture 4.0", "Current education focused on digitalization, sensors, data, automation and applied field innovation."),
            new("Backend development C#/.NET", "Hands-on practice with Blazor, APIs, SQL, layered architecture, authentication, Docker and deployment."),
            new("IoT and machine learning with Python", "Exploration of telemetry, data processing, hardware prototypes and models applied to agricultural problems."),
            new("International work and customer service", "Cross-cultural communication, sales, adaptability and direct work with people in demanding environments.")
        ],
        SkillGroups =
        [
            new("Agro / Agrifood", ["Agribusiness", "Agrifood management", "Traceability", "Livestock production", "Agriculture 4.0"]),
            new("Software", ["C#", ".NET", "Blazor", "WPF", "SQL", "Docker", "Git"]),
            new("Data", ["Python", "Machine learning", "Dashboards", "Exploratory analysis", "Data modeling"]),
            new("IoT / hardware", ["Raspberry Pi", "ZimaBoard", "Sensors", "Telemetry", "Linux"]),
            new("Languages", ["Spanish", "English", "French", "Italian"])
        ],
        CvDownload = new(
            "Downloadable CV",
            "This block is ready for the final public CV. For now it downloads a summarized HTML version; later it can be replaced by a PDF without changing the interface.",
            "Download CV",
            "Prepared for PDF, ATS version and professional links.",
            ["Agrotech / Software profile", "Education", "Projects", "Skills", "Languages"]),
        AvailableFor = new(
            "Available for",
            "Collaborations and opportunities where agricultural knowledge meets practical technical execution.",
            ["Agrotech opportunities", "IoT projects", "Backend .NET", "Agricultural automation", "Technical collaboration", "Internships / junior-mid tech-agro roles"]),
        ContactTitle = "Contact",
        Contact = new(
            "Open to job opportunities, technical collaborations and projects where software, data and infrastructure improve field decisions.",
            "Name",
            "Email",
            "Message",
            "Send",
            "Email",
            "LinkedIn",
            "GitHub",
            "Downloadable CV",
            "Visual form prepared to connect with a backend or external service."),
        FooterText = "Juan Ignacio · Agrotech, software and applied innovation."
    };

    private static PortfolioContent French => Spanish with
    {
        LanguageCode = "fr",
        Seo = new(
            "Juan Ignacio | Agrotech, Logiciel, IoT et Données",
            "Portfolio professionnel de Juan Ignacio : profil hybride en Agrotech, logiciel C#/.NET, IoT agricole, données, automatisation et projets liés au secteur agroalimentaire.",
            "Juan Ignacio, Agrotech, Agriculture 4.0, logiciel agricole, C#, .NET, Blazor, IoT agricole, machine learning, Python, automatisation agricole, portfolio",
            "Juan Ignacio",
            "Juan Ignacio | Agrotech, Logiciel et IoT",
            "Portfolio professionnel autour de l’Agrotech, du logiciel, de l’IoT, des données et de l’automatisation appliquée à l’agriculture."),
        Nav = new("À propos", "Objectif", "Domaines", "Projets", "Parcours", "Compétences", "CV", "Contact"),
        Hero = new(
            "Juan Ignacio",
            "Agrotechnologie, logiciel et innovation appliquée à l’agriculture.",
            "Agrotech · Logiciel · IoT · Données",
            "Profil hybride entre agribusiness, systèmes agroalimentaires et technologie. Je conçois des solutions avec C#/.NET, Python, capteurs, données et automatisation pour améliorer la prise de décision dans les opérations agricoles.",
            ["Agrotech", "Backend .NET", "IoT agricole", "Données et dashboards", "Automatisation", "Profil international"],
            new("Voir les projets", "Télécharger le CV", "Contacter")),
        AboutTitle = "À propos",
        AboutText = "Je combine une formation en Agribusiness et Gestion des Agroaliments avec le développement logiciel, l’IoT et les technologies appliquées au terrain. J’aime travailler près des problèmes réels : inventaires d’élevage, traçabilité, capture de données, tableaux de bord, automatisation et outils utiles aux producteurs, équipes techniques et entreprises agroalimentaires.",
        ProfessionalGoal = new(
            "Objectif professionnel",
            "Je recherche des opportunités en Agrotech, Agriculture 4.0, logiciel appliqué à l’agriculture, IoT agricole, données et automatisation. Je m’intéresse particulièrement aux entreprises technologiques liées au secteur agroalimentaire, où je peux apporter à la fois une compréhension métier et une exécution technique concrète.",
            ["Agrotech", "Agriculture 4.0", "Logiciel agricole", "IoT agricole", "Données", "Automatisation", "Secteur agroalimentaire"]),
        InterestsTitle = "Domaines d’intérêt",
        Interests =
        [
            new("Agrotech / Agriculture 4.0", "Digitalisation des processus productifs, traçabilité, suivi et outils d’aide à la décision."),
            new("Backend C# / .NET", "APIs, services, logique métier, persistance et architecture maintenable pour des produits réels."),
            new("IoT et capteurs", "Capture de variables terrain, télémétrie, matériel edge et connexion entre dispositifs et logiciel."),
            new("Machine Learning appliqué à l’agriculture", "Modèles Python pour explorer des tendances, classifier des données et soutenir la prédiction."),
            new("Automatisation agricole", "Prototypes et flux qui réduisent le travail manuel, améliorent la précision et facilitent l’exploitation des données."),
            new("Data / dashboards", "Visualisation claire des inventaires, indicateurs, alertes, évolutions productives et états système."),
            new("Raspberry Pi / ZimaBoard", "Infrastructure personnelle pour laboratoire, serveurs, télémétrie, stockage et tests orientés terrain.")
        ],
        ProjectsTitle = "Projets",
        ProjectsIntro = "Cas de portfolio orientés vers des problèmes concrets avec logiciel, données et infrastructure légère.",
        ProjectLabels = new("Problème", "Technologies", "Rôle", "État", "Prochaine étape", "Voir le projet", "Voir le dépôt", "Aperçu du projet à venir"),
        Projects =
        [
            new("CattleCat / inventaire bovin", "Système desktop pour gérer animaux, lots, mouvements et données productives d’une exploitation.", "Les données d’élevage sont souvent dispersées entre tableurs, papier et mémoire opérationnelle, ce qui complique traçabilité, contrôle du stock et décision.", ["C#", "WPF", "SQL Server", "Entity Framework"], "Conception fonctionnelle, modélisation des données, interface desktop et logique de gestion.", "Fonctionnel", "Ajouter des rapports, l’export de données et une possible version web ou mobile.", "Voir plus", ImageUrl: CattleCatImage, ImageAlt: "Placeholder visuel de CattleCat avec panneaux d’inventaire bovin"),
            new("Regional League App", "Plateforme web pour gérer ligues régionales, clubs, calendriers, résultats, classements, buteurs et contributeurs.", "Les compétitions locales ont besoin d’un outil simple pour publier des informations fiables et coordonner la saisie des résultats sans processus manuel lourd.", ["Blazor", ".NET", "PostgreSQL", "Docker", "SignalR"], "Architecture, backend, UI Blazor, modèle de domaine, déploiement et modules d’administration.", "En développement", "Améliorer l’expérience publique, les permissions par contributeur et le flux de résultats en direct.", "Voir plus", ImageUrl: RegionalLeagueImage, ImageAlt: "Placeholder visuel de Regional League App avec tableau de résultats"),
            new("ZimaBoard home server / laboratoire de télémétrie", "Serveur domestique pour expérimenter avec services, stockage, sauvegardes, télémétrie et déploiements légers.", "Les projets IoT et data ont besoin d’un environnement stable pour tester des services, recevoir des mesures et simuler une infrastructure edge avant le terrain.", ["ZimaBoard", "Linux", "Docker", "IoT", "Networking"], "Installation, configuration de services, tests d’infrastructure et documentation du laboratoire.", "Prototype", "Intégrer dashboards de capteurs et pipelines de données agricoles.", "Voir plus", ImageUrl: ZimaBoardImage, ImageAlt: "Placeholder visuel de ZimaBoard Home Server et laboratoire de télémétrie"),
            new("Prototype de robot agricole autonome", "Exploration à petite échelle de navigation, captation et automatisation de tâches agricoles.", "De nombreuses tâches répétitives peuvent bénéficier de robots petits, économiques et modulaires pour inspection, suivi ou assistance.", ["Raspberry Pi", "Python", "Capteurs", "Vision", "Contrôle"], "Concept technique, sélection du matériel, essais capteurs et architecture initiale.", "Idée avancée", "Construire un MVP avec châssis, lecture de capteurs et navigation de base.", "Voir plus", ImageUrl: RobotImage, ImageAlt: "Placeholder visuel de robot agricole autonome avec capteurs"),
            new("Landing ecommerce multilingue pour bidets", "Landing commerciale pour présenter produits de bain et bidets à des publics internationaux.", "Un produit physique destiné à plusieurs marchés doit communiquer valeur, confiance et bénéfices avec un contenu localisé.", ["HTML", "CSS", "JavaScript", "SEO", "i18n"], "Structure de landing, copy multilingue, design responsive et base SEO.", "Prototype", "Connecter catalogue, analytics et formulaire commercial réel.", "Voir plus", ImageUrl: EcommerceImage, ImageAlt: "Placeholder visuel de landing ecommerce multilingue pour bidets")
        ],
        ExperienceTitle = "Parcours et formation",
        Experience =
        [
            new("Technicien en Agribusiness", "Base technique en production, gestion, commercialisation et chaînes agroalimentaires."),
            new("Licence en Gestion des Agroaliments", "Formation universitaire avancée centrée sur gestion, qualité, processus et vision systémique du secteur agroalimentaire. Mémoire en attente."),
            new("Agrotechnologie / Agriculture 4.0", "Formation actuelle orientée digitalisation, capteurs, données, automatisation et innovation appliquée au terrain."),
            new("Développement backend C#/.NET", "Pratique avec Blazor, APIs, SQL, architecture en couches, authentification, Docker et déploiement."),
            new("IoT et machine learning avec Python", "Exploration de télémétrie, traitement de données, prototypes hardware et modèles appliqués aux problèmes agricoles."),
            new("Expérience internationale et relation client", "Communication interculturelle, vente, adaptabilité et travail direct avec des personnes dans des environnements exigeants.")
        ],
        SkillsTitle = "Compétences",
        SkillGroups =
        [
            new("Agro / Agroalimentaire", ["Agribusiness", "Gestion agroalimentaire", "Traçabilité", "Production bovine", "Agriculture 4.0"]),
            new("Logiciel", ["C#", ".NET", "Blazor", "WPF", "SQL", "Docker", "Git"]),
            new("Données", ["Python", "Machine learning", "Dashboards", "Analyse exploratoire", "Modélisation de données"]),
            new("IoT / matériel", ["Raspberry Pi", "ZimaBoard", "Capteurs", "Télémétrie", "Linux"]),
            new("Langues", ["Espagnol", "Anglais", "Français", "Italien"])
        ],
        CvDownload = new(
            "CV téléchargeable",
            "Ce bloc est prêt pour le CV public final. Pour l’instant, il télécharge une version HTML résumée ; ensuite, le fichier pourra être remplacé par un PDF sans changer l’interface.",
            "Télécharger le CV",
            "Préparé pour PDF, version ATS et liens professionnels.",
            ["Profil Agrotech / Logiciel", "Formation", "Projets", "Compétences", "Langues"]),
        AvailableFor = new(
            "Disponible pour",
            "Collaborations et opportunités où la connaissance agricole rencontre une exécution technique concrète.",
            ["Opportunités Agrotech", "Projets IoT", "Backend .NET", "Automatisation agricole", "Collaboration technique", "Stages / postes junior-mid tech-agro"]),
        ContactTitle = "Contact",
        Contact = new(
            "Ouvert aux opportunités professionnelles, collaborations techniques et projets où logiciel, données et infrastructure améliorent les décisions sur le terrain.",
            "Nom",
            "Email",
            "Message",
            "Envoyer",
            "Email",
            "LinkedIn",
            "GitHub",
            "CV téléchargeable",
            "Formulaire visuel préparé pour être connecté à un backend ou à un service externe."),
        FooterText = "Juan Ignacio · Agrotech, logiciel et innovation appliquée."
    };
}
