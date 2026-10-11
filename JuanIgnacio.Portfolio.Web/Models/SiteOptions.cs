namespace JuanIgnacio.Portfolio.Web.Models;

public sealed class SiteOptions
{
    public const string SectionName = "Portfolio";

    public string Email { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;
    public string GitHubUrl { get; set; } = string.Empty;
    public string CvUrl { get; set; } = "cv/Juan-Ignacio-CV.html";
    public string PublicUrl { get; set; } = string.Empty;
    public string SocialImageUrl { get; set; } = "images/social-preview.png";
    public string ContactFormMode { get; set; } = "mailto";
    public string ContactApiUrl { get; set; } = string.Empty;
    public string FormspreeUrl { get; set; } = string.Empty;
    public List<ProjectScreenshot> CattleCatScreenshots { get; set; } = [];

    public bool HasCv => !string.IsNullOrWhiteSpace(CvUrl) &&
        !CvUrl.EndsWith("Juan-Ignacio-CV.html", StringComparison.OrdinalIgnoreCase);

    public string ResolvedCvUrl => string.IsNullOrWhiteSpace(CvUrl) ? "cv/Juan-Ignacio-CV.html" : CvUrl;
    public string ResolvedPublicUrl => string.IsNullOrWhiteSpace(PublicUrl) ? "/" : PublicUrl;
    public string ResolvedSocialImageUrl => string.IsNullOrWhiteSpace(SocialImageUrl) ? "images/social-preview.png" : SocialImageUrl;
}

public sealed class ProjectScreenshot
{
    public string Url { get; set; } = string.Empty;
    public Dictionary<string, string> Alt { get; set; } = [];
    public string GetAlt(string language) => Alt.GetValueOrDefault(language) ?? Alt.GetValueOrDefault("es") ?? "CattleCat";
}
