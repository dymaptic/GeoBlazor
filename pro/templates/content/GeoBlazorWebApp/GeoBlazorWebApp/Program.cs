using Microsoft.AspNetCore.StaticFiles;
#if (IndividualLocalAuth && UseServer)
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
#elseif (IndividualLocalAuth)
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
#endif
#if (UseWebAssembly)
using GeoBlazorWebApp.Client.Pages;
#endif
using GeoBlazorWebApp.Components;
#if (IndividualLocalAuth)
using GeoBlazorWebApp.Components.Account;
using GeoBlazorWebApp.Data;

#endif
#if (UsePro)
using dymaptic.GeoBlazor.Pro;
#else
using dymaptic.GeoBlazor.Core;

#endif
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

#if (IndividualLocalAuth)
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
#if (UseServer)
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
#endif

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();
#if (!UseServer)
builder.Services.AddAuthorization();
#endif

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
#if (UseLocalDB)
    options.UseSqlServer(connectionString));
#else
    options.UseSqlite(connectionString));
#endif
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

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
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
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
    .AddAdditionalAssemblies(typeof(GeoBlazorWebApp.Client._Imports).Assembly);
#endif

#if (IndividualLocalAuth)
// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

#endif
app.Run();
