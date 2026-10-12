using JuanIgnacio.Portfolio.Web.Components;
using JuanIgnacio.Portfolio.Web.Models;
using JuanIgnacio.Portfolio.Web.Services;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<PortfolioContentService>();
builder.Services.AddSingleton<CvAvailabilityService>();
builder.Services.Configure<SiteOptions>(
    builder.Configuration.GetSection(SiteOptions.SectionName));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path.Equals("/robots.txt", StringComparison.OrdinalIgnoreCase))
    {
        var options = context.RequestServices.GetRequiredService<IOptions<SiteOptions>>();
        var publicUrl = ResolvePublicUrl(options.Value, context);
        var body = $"""
User-agent: *
Allow: /

Sitemap: {publicUrl}sitemap.xml
""";

        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(body);
        return;
    }

    if (context.Request.Path.Equals("/sitemap.xml", StringComparison.OrdinalIgnoreCase))
    {
        var options = context.RequestServices.GetRequiredService<IOptions<SiteOptions>>();
        var publicUrl = ResolvePublicUrl(options.Value, context);
        var body = $"""
<?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>{WebUtility.HtmlEncode(publicUrl)}</loc>
    <changefreq>monthly</changefreq>
    <priority>1.0</priority>
  </url>
</urlset>
""";

        context.Response.ContentType = "application/xml";
        await context.Response.WriteAsync(body);
        return;
    }

    await next();
});

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static string ResolvePublicUrl(SiteOptions options, HttpContext context)
{
    var publicUrl = string.IsNullOrWhiteSpace(options.PublicUrl)
        ? $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/"
        : options.PublicUrl.Trim();

    return publicUrl.EndsWith('/') ? publicUrl : $"{publicUrl}/";
}
