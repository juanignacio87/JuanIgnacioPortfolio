namespace JuanIgnacio.Portfolio.Web.Models;

public sealed class SiteOptions
{
    public const string SectionName = "Portfolio";

    public string Email { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;
    public string GitHubUrl { get; set; } = string.Empty;
    public string CvUrl { get; set; } = "cv/Juan-Ignacio-CV.html";
    public string PublicUrl { get; set; } = string.Empty;
    public string SocialImageUrl { get; set; } = "images/social-preview.svg";
    public string ContactFormMode { get; set; } = "mailto";
    public string ContactApiUrl { get; set; } = string.Empty;
    public string FormspreeUrl { get; set; } = string.Empty;

    public string ResolvedCvUrl => string.IsNullOrWhiteSpace(CvUrl) ? "cv/Juan-Ignacio-CV.html" : CvUrl;
    public string ResolvedPublicUrl => string.IsNullOrWhiteSpace(PublicUrl) ? "/" : PublicUrl;
    public string ResolvedSocialImageUrl => string.IsNullOrWhiteSpace(SocialImageUrl) ? "images/social-preview.svg" : SocialImageUrl;
}
