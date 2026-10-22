using JuanIgnacio.Portfolio.Web.Components;
using JuanIgnacio.Portfolio.Web.Models;
using JuanIgnacio.Portfolio.Web.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
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

var proxyAddress = builder.Configuration["ReverseProxy:KnownProxy"];
var hasTrustedProxy = !string.IsNullOrWhiteSpace(proxyAddress);
IPAddress? trustedProxy = null;
if (hasTrustedProxy)
{
    if (!IPAddress.TryParse(proxyAddress, out trustedProxy))
        throw new InvalidOperationException("ReverseProxy:KnownProxy must be a literal IP address.");
    var proxy = trustedProxy;

    builder.Services.Configure<ForwardedHeadersOptions>(options =>
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        options.ForwardLimit = 1;
        options.KnownIPNetworks.Clear();
        options.KnownProxies.Clear();
        options.KnownProxies.Add(proxy);
        if (proxy.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            options.KnownProxies.Add(proxy.MapToIPv6());
    });
    builder.Services.AddHttpsRedirection(options => options.HttpsPort = 443);
}

// This stateless deployment deliberately invalidates old antiforgery cookies on restart.
if (builder.Configuration.GetValue<bool>("Hosting:EphemeralDataProtection"))
    builder.Services.AddDataProtection().UseEphemeralDataProtectionProvider();

var app = builder.Build();

// Trust only the configured connector, before anything reads the external scheme.
if (trustedProxy is not null)
{
    var trustedPeer = trustedProxy.MapToIPv6();
    app.UseWhen(context => context.Connection.RemoteIpAddress?.MapToIPv6().Equals(trustedPeer) == true,
        branch => branch.UseForwardedHeaders());
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (!app.Environment.IsDevelopment())
{
    app.UseWhen(context => !context.Request.Path.Equals("/health", StringComparison.OrdinalIgnoreCase),
        branch => branch.UseHttpsRedirection());
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

app.MapStaticAssets();

app.MapGet("/health", () => Results.Text("OK", "text/plain")).AllowAnonymous();

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
