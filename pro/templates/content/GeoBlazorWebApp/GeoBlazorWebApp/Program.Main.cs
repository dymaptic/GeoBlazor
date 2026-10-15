using Microsoft.AspNetCore.StaticFiles;
#if (UseWebAssembly)
using GeoBlazorWebApp.Client.Pages;
#endif
using GeoBlazorWebApp.Components;
#if (UsePro)
using dymaptic.GeoBlazor.Pro;
#else
using dymaptic.GeoBlazor.Core;
#endif

namespace GeoBlazorWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
          #if (UseServer && UseWebAssembly && IndividualLocalAuth)
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents()
            .AddAuthenticationStateSerialization();
          #elif (UseServer && UseWebAssembly)
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
          #elif (UseServer)
            .AddInteractiveServerComponents();
          #elif (UseWebAssembly && IndividualLocalAuth)
            .AddInteractiveWebAssemblyComponents()
            .AddAuthenticationStateSerialization();
          #elif (UseWebAssembly)
            .AddInteractiveWebAssemblyComponents();
          #endif

        #if (UsePro)
        builder.Services.AddGeoBlazorPro(builder.Configuration);
        #else
        builder.Services.AddGeoBlazor(builder.Configuration);

        #endif
        var app = builder.Build();

        // Configure the HTTP request pipeline.
#if (UseWebAssembly || IndividualLocalAuth)
        if (app.Environment.IsDevelopment())
        {
#if (UseWebAssembly)
            app.UseWebAssemblyDebugging();
#endif
#if (IndividualLocalAuth)
            app.UseMigrationsEndPoint();
#endif
        }
        else
#else
        if (!app.Environment.IsDevelopment())
#endif
        {
            app.UseExceptionHandler("/Error");
        #if (HasHttpsProfile)
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        #endif
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        #if (HasHttpsProfile)
        app.UseHttpsRedirection();

        #endif
        app.UseAntiforgery();

        app.MapStaticAssets();
        
        #if (UseServer && UseWebAssembly)
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
        #elif (UseServer)
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        #elif (UseWebAssembly)
        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode()
        #else
        app.MapRazorComponents<App>();
        #endif
        #if (UseWebAssembly)
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
        #endif

        app.Run();
    }
}
