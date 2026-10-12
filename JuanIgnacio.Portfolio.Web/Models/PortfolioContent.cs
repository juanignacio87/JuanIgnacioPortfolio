namespace JuanIgnacio.Portfolio.Web.Models;

public sealed record LanguageOption(string Code, string Label, string NativeLabel);

public sealed record CtaLabels(string Projects, string Cv, string Contact);

public sealed record SeoContent(
    string Title,
    string Description,
    string Keywords,
    string Author,
    string SocialTitle,
    string SocialDescription);

public sealed record NavigationLabels(
    string About,
    string Goal,
    string Interests,
    string Projects,
    string Experience,
    string Skills,
    string Cv,
    string Contact);

public sealed record HeroContent(
    string Name,
    string Tagline,
    string Eyebrow,
    string Summary,
    IReadOnlyList<string> Highlights,
    CtaLabels Ctas);

public sealed record InterestArea(string Title, string Description);

public enum ProjectStage { Published, InDevelopment, Conceptual, Coursework }

public sealed record ProjectItem(
    string Title,
    string Description,
    string Problem,
    IReadOnlyList<string> Technologies,
    string Role,
    string Status,
    string NextStep,
    string MoreLabel,
    string ImageUrl = "",
    string ImageAlt = "",
    string ProjectUrl = "",
    string RepositoryUrl = "",
    ProjectStage Stage = ProjectStage.Conceptual);

public sealed record ProjectLabels(
    string Problem,
    string Technologies,
    string Role,
    string Status,
    string NextStep,
    string ViewProject,
    string ViewRepository,
    string ImagePlaceholder);

public sealed record TimelineItem(string Title, string Detail);

public sealed record SkillGroup(string Title, IReadOnlyList<string> Skills);

public sealed record ProfessionalGoalContent(
    string Title,
    string Text,
    IReadOnlyList<string> FocusAreas);

public sealed record CvDownloadContent(
    string Title,
    string Text,
    string PrimaryAction,
    string SecondaryText,
    IReadOnlyList<string> Includes);

public sealed record AvailableForContent(
    string Title,
    string Text,
    IReadOnlyList<string> Items);

public sealed record ContactLabels(
    string Intro,
    string Name,
    string Email,
    string Message,
    string Send,
    string EmailLabel,
    string LinkedInLabel,
    string GitHubLabel,
    string CvLabel,
    string FormNote);

public sealed record PortfolioContent(
    string LanguageCode,
    SeoContent Seo,
    NavigationLabels Nav,
    HeroContent Hero,
    string AboutTitle,
    string AboutText,
    ProfessionalGoalContent ProfessionalGoal,
    string InterestsTitle,
    IReadOnlyList<InterestArea> Interests,
    string ProjectsTitle,
    string ProjectsIntro,
    ProjectLabels ProjectLabels,
    IReadOnlyList<ProjectItem> Projects,
    string ExperienceTitle,
    IReadOnlyList<TimelineItem> Experience,
    string SkillsTitle,
    IReadOnlyList<SkillGroup> SkillGroups,
    CvDownloadContent CvDownload,
    AvailableForContent AvailableFor,
    string ContactTitle,
    ContactLabels Contact,
    string FooterText)
{
    public VisualContent Visual { get; init; } = default!;
    public FeaturedContent Featured { get; init; } = default!;
}

public sealed record VisualContent(string Home, string Skip, string Navigation, string Languages,
    string Menu, string FieldCaption, string FieldLabel, string FieldData, string ProfileIntro,
    string FeaturedLabel, string OtherProjects, string Pending, string CvPending, string GalleryPending,
    string LanguagesTitle, string ContactKicker, string FooterNote);

public sealed record FeaturedContent(string Intro, IReadOnlyList<string> Features, string GalleryTitle);
