---
layout: page
title: "GeoBlazor Hybrid in MAUI"
nav_order: 11
---

# GeoBlazor Hybrid in MAUI

GeoBlazor, like Blazor, pretty much "just works" with the Blazor Hybrid MAUI templates, allowing you 
to deploy your application to Android, iOS, Mac, and Windows as packages stored or installable apps.
Below are a few key points to keep in mind when using GeoBlazor with MAUI.

## Injecting the API Key

By default, MAUI does not use the same `IConfiguration` settings as Blazor and Asp.NET Core. But you 
can easily add support for this feature with the following code (also available in our `dymaptic.GeoBlazor.Samples.MAUI` 
sample application).

1. In `MauiProgram.cs`

    ```csharp
    builder.Services.AddGeoBlazor();
    
    var executingAssembly = Assembly.GetExecutingAssembly();
    
    using Stream stream = executingAssembly
        .GetManifestResourceStream("YOUR.PROJECT.NAMESPACE.appsettings.json")!;
    
    IConfigurationRoot config = new ConfigurationBuilder()
        .AddUserSecrets(executingAssembly)
        .AddJsonStream(stream)
        .Build();
    builder.Configuration.AddConfiguration(config);
    ```

3. Create the file `appsettings.json` in the root of your MAUI project, and add the `ArcGISApiKey`
   as described in [Getting Started](gettingStarted).
3. Alternatively, you can also create a `secrets.json` after adding the above code.

## Using the Android Emulator

The current Android Emulator on Windows does not have OpenGL/WebGL support turned on by default. Since ArcGIS uses
WebGL, you will need to enable this feature, or you will get an error on the first map render.

1. Use your IDE's link to the Android Virtual Device (AVD) Manager to open the AVD Manager.
2. Create a new virtual device with the latest Android api version.
3. Open a command prompt or terminal, and run the following command to list the available AVDs.

    ```powershell
    "C:\Program Files (x86)\Android\android-sdk\emulator\emulator.exe" -list-avds
    ```

5. Find your new virtual device from the list, then run the following command to launch this device
   with OpenGL/WebGL support enabled. 

    ```powershell
    "C:\Program Files (x86)\Android\android-sdk\emulator\emulator.exe" -avd "YOUR_DEVICE_NAME" -feature GLESDynamicVersion
    ```
   
5. Once the emulator is running, you may launch and debug your application from the IDE as normal.