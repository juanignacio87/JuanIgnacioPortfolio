using JuanIgnacio.Portfolio.Web.Models;

namespace JuanIgnacio.Portfolio.Web.Services;

public sealed class CvAvailabilityService(IWebHostEnvironment environment)
{
    public CvFile? GetAvailableFile(SiteOptions options, string language)
    {
        if (!options.CvFiles.TryGetValue(language, out var url) ||
            string.IsNullOrWhiteSpace(url) || !url.StartsWith("/cv/", StringComparison.Ordinal)) return null;

        var name = url[4..];
        if (name.Contains('/') || name.Contains('\\') || name.Contains('?') || name.Contains('#') ||
            !name.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)) return null;

        // Check on every render so adding a final PDF requires no configuration toggle.
        var file = environment.WebRootFileProvider.GetFileInfo($"cv/{name}");
        return file.Exists && !file.IsDirectory && file.Length > 0 ? new CvFile(url, name) : null;
    }
}

public sealed record CvFile(string Url, string FileName);
