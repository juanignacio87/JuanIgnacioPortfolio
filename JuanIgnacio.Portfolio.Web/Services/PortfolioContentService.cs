using JuanIgnacio.Portfolio.Web.Models;

namespace JuanIgnacio.Portfolio.Web.Services;

// Copy is centralised here; technical identifiers are shared between languages.
public sealed class PortfolioContentService
{
    public IReadOnlyList<LanguageOption> Languages { get; } =
        [new("es", "ES", "Español"), new("it", "IT", "Italiano"), new("en", "EN", "English"), new("fr", "FR", "Français")];
    public PortfolioContent Get(string code) => code switch { "it" => Italian, "en" => English, "fr" => French, _ => Spanish };
    private static ProjectItem Cattle(string description, string role, string status, string next) => new("CattleCat", description, "", ["C#", "WPF", "Entity Framework 6", "SQL Server"], role, status, next, "", RepositoryUrl: "https://github.com/juanignacio87/CattleCat", Stage: ProjectStage.Published);

    private static PortfolioContent Spanish => new("es",
        new("Juan Ignacio Bastonero | Agronegocios, software y Agro 4.0", "Conecto experiencia agropecuaria con software, datos e IoT. Portfolio de Juan Ignacio Bastonero: CattleCat y tecnología aplicada al campo.", "Agrotech, Agro 4.0, C#, IoT, agronegocios", "Juan Ignacio Bastonero", "Juan Ignacio Bastonero · Campo tecnológico", "Agronegocios, desarrollo de software y Agro 4.0. Experiencia de campo, mirada tecnológica."),
        new("Perfil", "Objetivo", "Áreas", "Proyectos", "Experiencia", "Tecnologías", "CV", "Contacto"),
        new("Juan Ignacio Bastonero", "Agronegocios + Desarrollo de software + Agro 4.0", "EXPERIENCIA DE CAMPO. MIRADA TECNOLÓGICA.", "Conecto la experiencia práctica agropecuaria con software, datos e IoT para abordar problemas reales del campo.", ["Agronegocios", "Software", "Datos e IoT"], new("Ver proyectos", "Descargar CV", "Contactar")),
        "Del campo al código.", "Soy Técnico en Agronegocios, con formación en Gestión de Agroalimentos y actualmente estudiante de Máster Agro 4.0. Mi experiencia práctica en explotaciones agropecuarias me permite entender los procesos y las necesidades antes de pensar en la tecnología. Hoy oriento mi desarrollo profesional hacia Agrotech, combinando esa base con software, datos y sistemas conectados.",
        new("Objetivo profesional", "Busco incorporarme a equipos que desarrollen tecnología útil para el sector agroalimentario: software de gestión, IoT agrícola, agricultura de precisión y automatización. Me interesan las oportunidades laborales, el intercambio técnico y la colaboración internacional.", ["Agrotech", "Software .NET", "IoT agrícola"]), "Perfil", [],
        "Tecnología con los pies en el campo.", "Proyectos propios y líneas de trabajo que conectan gestión, software y agricultura de precisión.",
        new("El desafío", "Tecnologías", "Mi aporte", "Estado", "Próximo paso", "Ver proyecto", "Ver repositorio", "Material visual pendiente"),
        [Cattle("Una herramienta de escritorio para gestionar inventarios y movimientos ganaderos con reglas de negocio claras.", "Desarrollo de la aplicación, modelo de datos y lógica de inventario.", "Funcional", "Evolución prevista: explorar una versión local con SQLite y una arquitectura conectada mediante PostgreSQL y una API; aún no desarrolladas."),
         new("RegionalLeagueApp", "Plataforma web para organizar ligas regionales, equipos, partidos y resultados.", "Centralizar la información de las competiciones.", ["C#", "Blazor", "PostgreSQL", "Docker"], "Desarrollo de software y diseño del dominio.", "En desarrollo", "Validar los flujos de gestión y completar la documentación.", "Detalles", Stage: ProjectStage.InDevelopment),
         new("NodoAgrícola", "Línea de trabajo para conectar sensores de campo con almacenamiento y visualización de datos.", "Obtener mediciones útiles fuera del escritorio.", ["Raspberry Pi", "ESP32", "IoT", "Python"], "Exploración de arquitectura y componentes.", "Conceptual", "Definir el primer caso de uso y validar un nodo de medición.", "Detalles"),
         new("Teledetección y agricultura de precisión", "Trabajos de formación sobre imágenes satelitales, índices de vegetación y lectura espacial del lote.", "Interpretar la variabilidad del campo.", ["Sentinel-2", "NDVI", "GIS", "Python"], "Análisis y aprendizaje aplicado.", "En formación", "Seleccionar y documentar un trabajo para publicar.", "Detalles", Stage: ProjectStage.Coursework),
         new("Visión artificial y sanidad bovina", "Concepto de exploración de imágenes para apoyar la observación sanitaria del ganado; no es una herramienta de diagnóstico.", "Explorar señales que merezcan revisión profesional.", ["Python", "Visión artificial", "Machine learning"], "Definición del problema y evaluación de viabilidad.", "Conceptual", "Definir datos, validación y colaboración veterinaria.", "Detalles")],
        "Una trayectoria que conecta disciplinas.",
        [new("Técnico en Agronegocios", "Formación en producción, gestión y comercialización agropecuaria."), new("Gestión de Agroalimentos", "Formación universitaria en cadenas agroalimentarias, procesos y calidad. Tesis pendiente."), new("Experiencia práctica agropecuaria", "Trabajo en explotaciones y contacto directo con la operación cotidiana del campo."), new("Experiencia internacional", "Adaptación a otros entornos, comunicación multilingüe y atención al cliente."), new("Máster Agro 4.0 · En curso", "Agricultura de precisión, teledetección y digitalización del agro."), new("Desarrollo tecnológico · Actualidad", "Proyectos propios con C#/.NET y exploración de datos, IoT y automatización.")],
        "Herramientas para conectar el sistema.",
        [new("Desarrollo de software", ["C#", ".NET", "WPF", "Blazor", "Entity Framework", "LINQ"]), new("Datos e infraestructura", ["SQL Server", "PostgreSQL", "Python", "Docker"]), new("Hardware conectado", ["Raspberry Pi", "ESP32", "IoT"]), new("Agricultura de precisión", ["Sentinel-2", "NDVI", "GIS"]), new("Idiomas", ["Español · Nativo", "Italiano · Fluido", "Francés · B2–C1", "Inglés · C1"])],
        new("CV", "Formación, experiencia y proyectos en un documento.", "Descargar CV", "CV PDF pendiente de publicación.", []),
        new("Disponible para", "Una mirada agropecuaria dentro de un equipo tecnológico.", ["Agrotech", "Backend .NET", "IoT", "Automatización", "Colaboración técnica"]),
        "Conversemos sobre el próximo desafío.", new("Busco oportunidades en Agrotech y equipos que conecten conocimiento del campo con software, datos y automatización. También estoy abierto al networking y a conversaciones técnicas en EIMA, Bologna.", "Nombre", "Correo", "Mensaje", "Enviar", "Correo", "LinkedIn", "GitHub", "Descargar CV", "Contacto pendiente de configuración."),
        "Juan Ignacio Bastonero · Agronegocios + Software + Agro 4.0")
    {
        Gallery = new("Abrir captura", "Seleccionar captura", "Cerrar visor", "Captura anterior", "Captura siguiente", "Captura {0} de {1}: {2}"),
        Messages = new("No se pudo completar la solicitud", "Ocurrió un error. Recargá la página para volver a intentarlo.", "Recargar", "Cerrar aviso", "ID de la solicitud"),
        Visual = new("Inicio", "Saltar al contenido", "Navegación principal", "Idioma", "Abrir navegación", "Campo tecnológico", "DEL LOTE AL DATO", "Software / Sensores / Decisiones", "PERFIL HÍBRIDO", "PROYECTO DESTACADO", "Otras líneas de trabajo", "Por configurar", "CV pendiente", "Capturas reales pendientes. No se muestran imágenes simuladas de la aplicación.", "Idiomas", "CONECTEMOS", "Una perspectiva internacional. Un propósito conectado al campo."),
        Featured = new("Inventario ganadero, con lógica de campo.", ["Gestión de establecimientos, lotes, usuarios y movimientos ganaderos.", "Stock por establecimiento, lote y categoría.", "Búsqueda y exportación CSV.", "Validación para impedir operaciones que generen stock negativo.", "Edición y desactivación lógica de registros."], "La aplicación, por dentro")
    };

    private static PortfolioContent Italian => Spanish with
    {
        Gallery = new("Apri la schermata", "Seleziona la schermata", "Chiudi il visualizzatore", "Schermata precedente", "Schermata successiva", "Schermata {0} di {1}: {2}"),
        LanguageCode = "it",
        Seo = new(
            "Juan Ignacio Bastonero | Agribusiness, sviluppo software e Agricoltura 4.0",
            "Esperienza nelle aziende agricole, sviluppo software, dati e IoT. Il portfolio Agrotech di Juan Ignacio Bastonero: CattleCat e tecnologie applicate all'agricoltura.",
            "Agrotech, Agricoltura 4.0, agribusiness, sviluppo software, C#, IoT, agricoltura di precisione",
            "Juan Ignacio Bastonero",
            "Juan Ignacio Bastonero · Agricoltura e tecnologia",
            "agribusiness, sviluppo software e Agricoltura 4.0. L'esperienza sul campo incontra la tecnologia."),
        Nav = new("Profilo", "Obiettivo", "Ambiti", "Progetti", "Esperienza", "Tecnologie", "CV", "Contatti"),
        Hero = new(
            "Juan Ignacio Bastonero",
            "Agribusiness + Sviluppo software + Agricoltura 4.0",
            "ESPERIENZA SUL CAMPO. APPROCCIO TECNOLOGICO.",
            "Unisco l'esperienza pratica nelle aziende agricole a software, dati e IoT per affrontare le esigenze concrete del settore.",
            ["Agribusiness", "Software", "Dati e IoT"],
            new("Scopri i progetti", "Scarica il CV", "Contattami")),
        AboutTitle = "Dal campo al codice.",
        AboutText = "Sono un tecnico specializzato in agribusiness, con una formazione in gestione agroalimentare e attualmente iscritto al Master Agro 4.0. L'esperienza pratica nelle aziende agricole mi aiuta a comprendere i processi e le esigenze operative prima di scegliere la tecnologia. Oggi sto orientando il mio percorso professionale verso l'Agrotech, integrando questa conoscenza del settore con lo sviluppo software, i dati e i sistemi connessi.",
        ProfessionalGoal = new(
            "Obiettivo professionale",
            "Cerco opportunità in team che sviluppano tecnologie utili al settore agroalimentare: software gestionali, IoT agricolo, agricoltura di precisione e automazione. Sono interessato a opportunità lavorative, scambi tecnici e collaborazioni internazionali.",
            ["Agrotech", "Software .NET", "IoT agricolo"]),
        InterestsTitle = "Ambiti di interesse",
        Interests = [],
        ProjectsTitle = "Tecnologia con solide radici nel campo.",
        ProjectsIntro = "Progetti personali e ambiti di lavoro che collegano gestione, sviluppo software e agricoltura di precisione.",
        ProjectLabels = new("La sfida", "Tecnologie", "Il mio contributo", "Stato", "Prossimo passo", "Scopri il progetto", "Vedi il repository", "Materiale visivo da aggiungere"),
        Projects =
        [
            Cattle(
                "Un'applicazione desktop per la gestione degli allevamenti bovini, delle consistenze e dei movimenti, con regole operative chiare.",
                "Sviluppo dell'applicazione, modello dei dati e logica di gestione delle consistenze.",
                "Operativo",
                "Evoluzione futura: valutare una versione locale con SQLite e un'architettura connessa tramite PostgreSQL e API; non ancora sviluppate.") with
            {
                MoreLabel = "Dettagli",
                ImageAlt = "CattleCat: applicazione per la gestione delle consistenze e dei movimenti bovini"
            },
            new("RegionalLeagueApp",
                "Piattaforma web per organizzare campionati regionali, squadre, partite e risultati.",
                "Riunire le informazioni delle competizioni in un unico sistema.",
                ["C#", "Blazor", "PostgreSQL", "Docker"],
                "Sviluppo software e modellazione del dominio.",
                "In sviluppo",
                "Validare i flussi di gestione e completare la documentazione.",
                "Dettagli",
                ImageAlt: "RegionalLeagueApp: piattaforma per la gestione dei campionati regionali",
                Stage: ProjectStage.InDevelopment),
            new("NodoAgrícola",
                "Un progetto allo studio per collegare i sensori di campo all'archiviazione e alla visualizzazione dei dati.",
                "Raccogliere misurazioni utili direttamente sul campo.",
                ["Raspberry Pi", "ESP32", "IoT", "Python"],
                "Esplorazione dell'architettura e dei componenti.",
                "Concettuale",
                "Definire il primo caso d'uso e validare un nodo di misura.",
                "Dettagli",
                ImageAlt: "NodoAgrícola: progetto di monitoraggio con sensori agricoli"),
            new("Telerilevamento e agricoltura di precisione",
                "Lavori formativi su immagini satellitari, indici di vegetazione e analisi spaziale degli appezzamenti.",
                "Interpretare la variabilità all'interno degli appezzamenti.",
                ["Sentinel-2", "NDVI", "GIS", "Python"],
                "Analisi e applicazione pratica delle competenze acquisite.",
                "Progetto formativo",
                "Selezionare e documentare un lavoro da pubblicare.",
                "Dettagli",
                ImageAlt: "Telerilevamento: analisi degli appezzamenti con immagini satellitari",
                Stage: ProjectStage.Coursework),
            new("Visione artificiale e salute bovina",
                "Un'idea per esplorare l'uso delle immagini nell'osservazione sanitaria dei bovini. Non è uno strumento diagnostico.",
                "Individuare segnali visivi da sottoporre a una valutazione professionale.",
                ["Python", "Computer vision", "Machine learning"],
                "Definizione del problema e valutazione della fattibilità.",
                "Concettuale",
                "Definire i dati, i criteri di validazione e la collaborazione veterinaria.",
                "Dettagli",
                ImageAlt: "Visione artificiale e salute bovina: progetto concettuale")
        ],
        ExperienceTitle = "Un percorso che unisce discipline diverse.",
        Experience =
        [
            new("Tecnico specializzato in agribusiness", "Formazione in produzione, gestione e commercializzazione nel settore agricolo e zootecnico."),
            new("Gestione agroalimentare", "Formazione universitaria sulle filiere agroalimentari, i processi e la qualità. Tesi ancora da completare."),
            new("Esperienza pratica nelle aziende agricole", "Esperienza lavorativa in aziende agricole e partecipazione diretta alle attività operative quotidiane."),
            new("Esperienza internazionale", "Adattamento a contesti diversi, comunicazione multilingue e assistenza ai clienti."),
            new("Master Agro 4.0 · In corso", "Agricoltura di precisione, telerilevamento e digitalizzazione del settore agricolo."),
            new("Sviluppo tecnologico · In corso", "Progetti personali con C#/.NET ed esplorazione di dati, IoT e automazione.")
        ],
        SkillsTitle = "Strumenti per connettere campo e tecnologia.",
        SkillGroups =
        [
            new("Sviluppo software", ["C#", ".NET", "WPF", "Blazor", "Entity Framework", "LINQ"]),
            new("Dati e infrastruttura", ["SQL Server", "PostgreSQL", "Python", "Docker"]),
            new("Hardware connesso", ["Raspberry Pi", "ESP32", "IoT"]),
            new("Agricoltura di precisione", ["Sentinel-2", "NDVI", "GIS"]),
            new("Lingue", ["Spagnolo · Madrelingua", "Italiano · Fluente", "Francese · B2–C1", "Inglese · C1"])
        ],
        CvDownload = new("CV", "Formazione, esperienza e progetti in un unico documento.", "Scarica il CV", "CV in PDF in attesa di pubblicazione.", []),
        AvailableFor = new("Disponibile per", "Una prospettiva agricola all'interno di un team tecnologico.", ["Agrotech", "Backend .NET", "IoT", "Automazione", "Collaborazione tecnica"]),
        ContactTitle = "Parliamo della prossima sfida.",
        Contact = new("Cerco opportunità in Agrotech e team che uniscano la conoscenza del settore agricolo a software, dati e automazione. Sono aperto anche a incontri professionali e scambi tecnici in occasione di EIMA a Bologna.", "Nome", "E-mail", "Messaggio", "Invia", "E-mail", "LinkedIn", "GitHub", "Scarica il CV", "Contatti da configurare."),
        FooterText = "Juan Ignacio Bastonero · Agribusiness + Software + Agricoltura 4.0",
        Visual = new("Inizio", "Vai al contenuto", "Navigazione principale", "Lingua", "Apri il menu", "Agricoltura e tecnologia", "DALL'APPEZZAMENTO AL DATO", "Software / Sensori / Decisioni", "UN PROFILO IBRIDO", "PROGETTO IN EVIDENZA", "Altri ambiti di lavoro", "Da configurare", "CV da aggiungere", "Schermate reali da aggiungere. Non vengono mostrate immagini simulate dell'applicazione.", "Lingue", "RESTIAMO IN CONTATTO", "Una prospettiva internazionale. Un obiettivo radicato nel mondo agricolo."),
        Featured = new("Gestione delle consistenze bovine, progettata sulle esigenze delle aziende agricole.",
            ["Gestione di aziende agricole, appezzamenti, utenti e movimenti dei bovini.",
             "Consistenze per azienda agricola, appezzamento e categoria.",
             "Ricerca ed esportazione CSV.",
             "Controlli per impedire operazioni che generino consistenze negative.",
             "Modifica e disattivazione logica delle registrazioni."],
            "Uno sguardo all'applicazione"),
        Messages = new("Impossibile completare la richiesta", "Si è verificato un errore. Ricarica la pagina per riprovare.", "Ricarica", "Chiudi l'avviso", "ID della richiesta")
    };

    private static PortfolioContent English => Spanish with
    {
        Gallery = new("Open screenshot", "Select screenshot", "Close viewer", "Previous screenshot", "Next screenshot", "Screenshot {0} of {1}: {2}"),
        Messages = new("The request could not be completed", "An error occurred. Reload the page to try again.", "Reload", "Dismiss notice", "Request ID"),
        LanguageCode = "en", Seo = new("Juan Ignacio Bastonero | Agribusiness, software & Agriculture 4.0", "Connecting hands-on farming experience with software, data and IoT. Juan Ignacio Bastonero's portfolio: CattleCat and technology for agriculture.", "Agrotech, Agriculture 4.0, C#, IoT", "Juan Ignacio Bastonero", "Juan Ignacio Bastonero · Connected agriculture", "Agribusiness, software development and Agriculture 4.0. Field experience meets technology."),
        Nav = new("Profile", "Goal", "Focus", "Projects", "Experience", "Technologies", "CV", "Contact"),
        Hero = new("Juan Ignacio Bastonero", "Agribusiness + Software development + Agriculture 4.0", "FIELD EXPERIENCE. A TECHNOLOGY MINDSET.", "I connect hands-on farming experience with software, data and IoT to tackle real agricultural challenges.", ["Agribusiness", "Software", "Data & IoT"], new("View projects", "Download CV", "Contact")),
        AboutTitle = "From the field to code.", AboutText = "I am an Agribusiness Technician with a background in Agrifood Management, currently studying for a master's degree in Agriculture 4.0. Hands-on experience on farms helps me understand the processes and needs before choosing the technology. I am now building a career in Agrotech, bringing that foundation together with software, data and connected systems.",
        ProfessionalGoal = new("Career direction", "I am looking to join teams building useful technology for the agrifood sector: management software, agricultural IoT, precision farming and automation. I welcome job opportunities, technical exchanges and international collaboration.", ["Agrotech", ".NET software", "Agricultural IoT"]),
        ProjectsTitle = "Technology grounded in agriculture.", ProjectsIntro = "Personal projects and areas of work linking management, software and precision agriculture.",
        ProjectLabels = new("The challenge", "Technologies", "My contribution", "Status", "Next step", "View project", "View repository", "Visual material pending"),
        Projects = [Cattle("A desktop tool for managing livestock inventory and movements with clear business rules.", "Application development, data model and inventory logic.", "Functional", "Future evolution: explore a local SQLite version and a connected PostgreSQL/API architecture; neither has been developed yet."), new("RegionalLeagueApp", "A web platform for organising regional leagues, teams, fixtures and results.", "Bring competition information into one place.", ["C#", "Blazor", "PostgreSQL", "Docker"], "Software development and domain modelling.", "In development", "Validate management workflows and complete documentation.", "Details", Stage: ProjectStage.InDevelopment), new("NodoAgrícola", "A proposed system connecting field sensors to data storage and visualisation.", "Collect useful measurements in the field.", ["Raspberry Pi", "ESP32", "IoT", "Python"], "Architecture and component exploration.", "Concept", "Define a use case and validate a sensing node.", "Details"), new("Remote sensing & precision agriculture", "Coursework exploring satellite imagery, vegetation indices and field-level spatial analysis.", "Understand variability across a field.", ["Sentinel-2", "NDVI", "GIS", "Python"], "Analysis and applied learning.", "Coursework", "Select and document a piece of work for publication.", "Details", Stage: ProjectStage.Coursework), new("Computer vision & cattle health", "A concept exploring images to support livestock health observation; not a diagnostic tool.", "Explore signs requiring professional assessment.", ["Python", "Computer vision", "Machine learning"], "Problem definition and feasibility assessment.", "Concept", "Define data, validation and veterinary collaboration.", "Details")],
        ExperienceTitle = "A path connecting disciplines.", Experience = [new("Agribusiness Technician", "Training in agricultural production, management and marketing."), new("Agrifood Management", "University-level studies in agrifood chains, processes and quality. Thesis pending."), new("Hands-on farming experience", "Work on farms and involvement in day-to-day operations."), new("International experience", "Adapting to new environments, multilingual communication and customer service."), new("Master's in Agriculture 4.0 · In progress", "Precision agriculture, remote sensing and agricultural digitalisation."), new("Technology development · Current", "Personal C#/.NET projects and exploration of data, IoT and automation.")],
        SkillsTitle = "Tools to connect the system.", SkillGroups = [new("Software development", ["C#", ".NET", "WPF", "Blazor", "Entity Framework", "LINQ"]), new("Data & infrastructure", ["SQL Server", "PostgreSQL", "Python", "Docker"]), new("Connected hardware", ["Raspberry Pi", "ESP32", "IoT"]), new("Precision agriculture", ["Sentinel-2", "NDVI", "GIS"]), new("Languages", ["Spanish · Native", "Italian · Fluent", "French · B2–C1", "English · C1"])],
        CvDownload = new("CV", "Education, experience and projects in one document.", "Download CV", "CV PDF awaiting publication.", []), AvailableFor = new("Open to", "An agricultural perspective within a technology team.", ["Agrotech", ".NET backend", "IoT", "Automation", "Technical collaboration"]),
        ContactTitle = "Let's discuss the next challenge.", Contact = new("I am looking for Agrotech opportunities and teams that bring agricultural knowledge together with software, data and automation. I am also open to networking and technical conversations at EIMA in Bologna.", "Name", "Email", "Message", "Send", "Email", "LinkedIn", "GitHub", "Download CV", "Contact details awaiting configuration."), FooterText = "Juan Ignacio Bastonero · Agribusiness + Software + Agriculture 4.0",
        Visual = new("Home", "Skip to content", "Main navigation", "Language", "Open navigation", "Connected agriculture", "FROM FIELD TO DATA", "Software / Sensors / Decisions", "A HYBRID PROFILE", "FEATURED PROJECT", "Other areas of work", "Not configured", "CV pending", "Real screenshots are still pending. No simulated application images are shown.", "Languages", "LET'S CONNECT", "An international outlook. A purpose rooted in agriculture."),
        Featured = new("Livestock inventory, built around farm operations.", ["Manage farms, lots, users and livestock movements.", "Stock by farm, lot and category.", "Search and CSV export.", "Validation prevents transactions that would create negative stock.", "Record editing and soft deactivation."], "Inside the application")
    };

    private static PortfolioContent French => Spanish with
    {
        Gallery = new("Ouvrir la capture", "Sélectionner la capture", "Fermer la visionneuse", "Capture précédente", "Capture suivante", "Capture {0} sur {1} : {2}"),
        Messages = new("La demande n'a pas pu être traitée", "Une erreur est survenue. Rechargez la page pour réessayer.", "Recharger", "Fermer le message", "Identifiant de la demande"),
        LanguageCode = "fr", Seo = new("Juan Ignacio Bastonero | Agribusiness, logiciel et Agriculture 4.0", "Relier l'expérience agricole de terrain au logiciel, aux données et à l'IoT. Portfolio de Juan Ignacio Bastonero : CattleCat et technologies pour l'agriculture.", "Agrotech, Agriculture 4.0, C#, IoT", "Juan Ignacio Bastonero", "Juan Ignacio Bastonero · Agriculture connectée", "Agribusiness, développement logiciel et Agriculture 4.0. Une expérience de terrain, une approche technologique."),
        Nav = new("Profil", "Objectif", "Domaines", "Projets", "Parcours", "Technologies", "CV", "Contact"),
        Hero = new("Juan Ignacio Bastonero", "Agribusiness + Développement logiciel + Agriculture 4.0", "L'EXPÉRIENCE DU TERRAIN. UNE APPROCHE TECHNOLOGIQUE.", "Je relie mon expérience pratique en agriculture au logiciel, aux données et à l'IoT pour répondre aux besoins concrets du terrain.", ["Agribusiness", "Logiciel", "Données et IoT"], new("Voir les projets", "Télécharger le CV", "Contacter")),
        AboutTitle = "Du terrain au code.", AboutText = "Technicien en agribusiness, formé à la gestion agroalimentaire et actuellement étudiant en master Agriculture 4.0, je m'appuie sur une expérience pratique en exploitation agricole. Elle me permet de comprendre les processus et les besoins avant de choisir une technologie. J'oriente aujourd'hui mon parcours vers l'Agrotech, en associant cette connaissance du terrain au développement logiciel, aux données et aux systèmes connectés.",
        ProfessionalGoal = new("Objectif professionnel", "Je souhaite rejoindre des équipes qui développent des technologies utiles au secteur agroalimentaire : logiciels de gestion, IoT agricole, agriculture de précision et automatisation. Je suis ouvert aux opportunités professionnelles, aux échanges techniques et aux collaborations internationales.", ["Agrotech", "Logiciel .NET", "IoT agricole"]),
        ProjectsTitle = "La technologie, ancrée dans le terrain.", ProjectsIntro = "Projets personnels et axes de travail à la croisée de la gestion, du logiciel et de l'agriculture de précision.",
        ProjectLabels = new("Le défi", "Technologies", "Ma contribution", "Statut", "Prochaine étape", "Voir le projet", "Voir le dépôt", "Visuels à fournir"),
        Projects = [Cattle("Une application de bureau pour gérer les stocks et les mouvements de bovins avec des règles métier explicites.", "Développement de l'application, modèle de données et logique de stock.", "Fonctionnel", "Évolution envisagée : explorer une version locale avec SQLite et une architecture connectée via PostgreSQL et une API ; elles ne sont pas encore développées."), new("RegionalLeagueApp", "Une plateforme web pour organiser les ligues régionales, les équipes, les rencontres et les résultats.", "Centraliser les informations des compétitions.", ["C#", "Blazor", "PostgreSQL", "Docker"], "Développement logiciel et modélisation du domaine.", "En développement", "Valider les parcours de gestion et compléter la documentation.", "Détails", Stage: ProjectStage.InDevelopment), new("NodoAgrícola", "Un axe de travail pour relier des capteurs de terrain au stockage et à la visualisation des données.", "Recueillir des mesures utiles sur le terrain.", ["Raspberry Pi", "ESP32", "IoT", "Python"], "Exploration de l'architecture et des composants.", "Concept", "Définir un cas d'usage et valider un nœud de mesure.", "Détails"), new("Télédétection et agriculture de précision", "Travaux de formation sur l'imagerie satellitaire, les indices de végétation et l'analyse spatiale des parcelles.", "Interpréter la variabilité d'une parcelle.", ["Sentinel-2", "NDVI", "GIS", "Python"], "Analyse et apprentissage appliqué.", "Travaux de formation", "Sélectionner et documenter un travail à publier.", "Détails", Stage: ProjectStage.Coursework), new("Vision par ordinateur et santé bovine", "Un concept d'analyse d'images pour appuyer l'observation sanitaire des bovins ; ce n'est pas un outil de diagnostic.", "Explorer les signes justifiant une évaluation professionnelle.", ["Python", "Vision par ordinateur", "Machine learning"], "Définition du problème et étude de faisabilité.", "Concept", "Définir les données, la validation et la collaboration vétérinaire.", "Détails")],
        ExperienceTitle = "Un parcours entre plusieurs disciplines.", Experience = [new("Technicien en agribusiness", "Formation en production, gestion et commercialisation agricoles."), new("Gestion agroalimentaire", "Études universitaires sur les filières, les processus et la qualité. Mémoire restant à finaliser."), new("Expérience agricole de terrain", "Travail en exploitation et participation aux activités quotidiennes."), new("Expérience internationale", "Adaptation à de nouveaux environnements, communication multilingue et relation client."), new("Master Agriculture 4.0 · En cours", "Agriculture de précision, télédétection et numérisation du secteur agricole."), new("Développement technologique · Aujourd'hui", "Projets personnels en C#/.NET et exploration des données, de l'IoT et de l'automatisation.")],
        SkillsTitle = "Des outils pour relier le système.", SkillGroups = [new("Développement logiciel", ["C#", ".NET", "WPF", "Blazor", "Entity Framework", "LINQ"]), new("Données et infrastructure", ["SQL Server", "PostgreSQL", "Python", "Docker"]), new("Matériel connecté", ["Raspberry Pi", "ESP32", "IoT"]), new("Agriculture de précision", ["Sentinel-2", "NDVI", "GIS"]), new("Langues", ["Espagnol · Langue maternelle", "Italien · Courant", "Français · B2–C1", "Anglais · C1"])],
        CvDownload = new("CV", "Formation, expérience et projets dans un document.", "Télécharger le CV", "CV PDF en attente de publication.", []), AvailableFor = new("Disponible pour", "Une connaissance du terrain au sein d'une équipe technologique.", ["Agrotech", "Backend .NET", "IoT", "Automatisation", "Collaboration technique"]),
        ContactTitle = "Parlons du prochain défi.", Contact = new("Je recherche des opportunités en Agrotech et des équipes qui associent connaissance agricole, logiciel, données et automatisation. Je suis également ouvert aux rencontres professionnelles et aux échanges techniques à EIMA, à Bologna.", "Nom", "E-mail", "Message", "Envoyer", "E-mail", "LinkedIn", "GitHub", "Télécharger le CV", "Coordonnées en attente de configuration."), FooterText = "Juan Ignacio Bastonero · Agribusiness + Logiciel + Agriculture 4.0",
        Visual = new("Accueil", "Aller au contenu", "Navigation principale", "Langue", "Ouvrir la navigation", "Agriculture connectée", "DE LA PARCELLE AUX DONNÉES", "Logiciel / Capteurs / Décisions", "UN PROFIL HYBRIDE", "PROJET À LA UNE", "Autres axes de travail", "À configurer", "CV à fournir", "Captures réelles à fournir. Aucune image simulée de l'application n'est affichée.", "Langues", "ÉCHANGEONS", "Une perspective internationale. Un engagement ancré dans le terrain."),
        Featured = new("Le stock bovin, pensé pour l'exploitation.", ["Gestion des exploitations, lots, utilisateurs et mouvements de bovins.", "Stock par exploitation, lot et catégorie.", "Recherche et export CSV.", "Validation empêchant les opérations qui rendraient le stock négatif.", "Modification et désactivation logique des enregistrements."], "Au cœur de l'application")
    };
}
