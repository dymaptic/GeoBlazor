# GeoBlazor Templates

This is the developer documentation file. For the packaged readme, see [PackageREADME.md](PackageREADME.md).

This package contains copies of the ASP.NET Core Blazor and MAUI Blazor hybrid Microsoft templates,
modified to include GeoBlazor components and dependencies.

To build the templates, run the C# build script from the repository root. To test with an
existing version of GeoBlazor, you will want to define the versions as command line arguments, like this:

```bash
dotnet ./build-tools/BuildTemplates.dll -c 4.0.1 -p 4.0.1 -i
```

Options:

- `-c, --core-version` - Override Core version
- `-p, --pro-version` - Override Pro version
- `-i, --install` - Install templates after building
- `-t, --templates-dir` - Override templates directory path
- `-h, --help` - Display help

This will also install the templates for you locally, so you can immediately test them from the command
line, Visual Studio, or VS Code (with the C# Dev Kit). To test from Rider, you must use the `New Solution` dialog,
select `Manage Templates`, and select the `.nupkg` file in the `bin/Release` folder.

The build script keeps the templates up to date with the latest versions of Microsoft NuGet packages. It reads
the `Directory.Build.props` file in this folder to set the versions of GeoBlazor.

It also copies the files in the `Pages` folder into all four templates, so you can update the page samples for all
templates by updating the files in that folder and running the script.

There unfortunately is not a lot of documentation on the custom templating process, but here are the links used to create
these templates:

- [Custom Templates for dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)
- [Dotnet Templating Wiki](https://github.com/dotnet/templating/wiki)
- [Blazor Web App Template Source Code](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp)
- [Blazor WebAssembly Standalone Template Source Code](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp)
- [MAUI Blazor Template Source Code](https://github.com/dotnet/maui/tree/main/src/Templates/src/templates/maui-blazor)
- [MAUI Blazor and Web Template Source Code](https://github.com/dotnet/maui/tree/main/src/Templates/src/templates/maui-blazor-solution)