namespace JuanIgnacio.Portfolio.Web.Models;

public sealed class SiteOptions
{
    public const string SectionName = "Portfolio";

    public string Email { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;
    public string GitHubUrl { get; set; } = string.Empty;
    public Dictionary<string, string> CvFiles { get; set; } = new(StringComparer.OrdinalIgnoreCase)
    {
        ["es"] = "/cv/Juan_Ignacio_Bastonero_CV_ES.pdf",
        ["it"] = "/cv/Juan_Ignacio_Bastonero_CV_IT.pdf",
        ["en"] = "/cv/Juan_Ignacio_Bastonero_CV_EN.pdf",
        ["fr"] = "/cv/Juan_Ignacio_Bastonero_CV_FR.pdf"
    };
    public string PublicUrl { get; set; } = string.Empty;
    public string SocialImageUrl { get; set; } = "images/social-preview.png";
    public string ContactFormMode { get; set; } = "mailto";
    public string ContactApiUrl { get; set; } = string.Empty;
    public string FormspreeUrl { get; set; } = string.Empty;
    public List<ProjectScreenshot> CattleCatScreenshots { get; set; } = [];

    public string ResolvedPublicUrl => string.IsNullOrWhiteSpace(PublicUrl) ? "/" : PublicUrl;
    public string ResolvedSocialImageUrl => string.IsNullOrWhiteSpace(SocialImageUrl) ? "images/social-preview.png" : SocialImageUrl;
}

public sealed class ProjectScreenshot
{
    public string Url { get; set; } = string.Empty;
    public Dictionary<string, string> Title { get; set; } = [];
    public Dictionary<string, string> Alt { get; set; } = [];
    public string GetTitle(string language) => Title.TryGetValue(language, out var title) && !string.IsNullOrWhiteSpace(title)
        ? title
        : "CattleCat";
    public string GetAlt(string language) => Alt.TryGetValue(language, out var alt) && !string.IsNullOrWhiteSpace(alt)
        ? alt
        : "CattleCat";
}
