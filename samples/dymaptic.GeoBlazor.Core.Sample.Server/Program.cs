using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Sample.Shared;
using Microsoft.AspNetCore.StaticFiles;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<SharedFileProvider>();
builder.Services.AddGeoBlazor();
builder.Configuration.AddInMemoryCollection();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".wsv"] = "application/octet-stream";

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions // NOTE: for some reason, you still need the plain "UseStaticFiles" call above
{
    ContentTypeProvider = provider
});

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();