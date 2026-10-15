# GeoBlazor Pro

[![NuGet](https://img.shields.io/nuget/v/dymaptic.GeoBlazor.Pro.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/dymaptic.GeoBlazor.Pro/)
[![Downloads](https://img.shields.io/nuget/dt/dymaptic.GeoBlazor.Pro?logo=nuget&label=downloads)](https://www.nuget.org/stats/packages/dymaptic.GeoBlazor.Pro?groupby=Version)

GeoBlazor Pro adds advanced ArcGIS Maps SDK for JavaScript features on top of [GeoBlazor Core](../ReadMe.md),
such as the Route service, ArcGIS REST service access, the complete feature query system, and the label, chart, and
popup creator tools. See the [package readme](src/dymaptic.GeoBlazor.Pro/ReadMe.md) for the feature list.

Pro is MIT licensed, like the rest of this repository. See the [LICENSE](../LICENSE). It ships as the NuGet package
`dymaptic.GeoBlazor.Pro`. A license key is not required. You can optionally register for a free key at
[licensing.dymaptic.com](https://licensing.dymaptic.com).

## Layout

- `src/` - The `dymaptic.GeoBlazor.Pro` library, its source generator, and the ESBuild project that compiles
  TypeScript to JavaScript.
- `test/` - Unit tests, the shared Blazor test components, and the Web App and MAUI test runners.
  See [Tests.md](test/Tests.md).
- `templates/` - The `dotnet new` project templates, packaged as `dymaptic.GeoBlazor.Templates`.
  See [templates/README.md](templates/README.md).
- `../build-tools/` - Build scripts at the repository root, including the template builder.

GeoBlazor Core lives at the repository root, one level up from this folder. Pro projects reference it directly, so
changes to Core and Pro can be made and tested together in one branch.

## Building Locally

Prerequisites:

- The .NET SDK version pinned in `global.json`.
- Node.js. Run `npm -v` to check. On Windows, add `C:\Program Files\nodejs` to your `PATH` if needed.
- On Windows, a current PowerShell, installed with `winget install Microsoft.Powershell`.

The solution includes projects from the `GeoBlazor-Samples` submodule, which a plain `git clone` leaves empty. Clone
with `git clone --recurse-submodules`, or in an existing clone run `git submodule update --init`. Then build the
solution:

```bash
dotnet build dymaptic.GeoBlazor.Pro.slnx
```

Building Core or Pro compiles the TypeScript to JavaScript through the `TriggerESBuild` and `TriggerProESBuild`
MSBuild targets. ESBuild skips itself when no files in `Scripts/` changed since the last build, tracked in
`.esbuild-record.json`. To force a JavaScript rebuild, run the ESBuild script with `-f` (Core) or `-f -p` (Pro), or run
`npm run debugBuild` from the project's source folder.

The test runner projects need an ArcGIS API key. They do not work with user secrets in the `Client` projects, so add an
`appsettings.json` to the `wwwroot` folder of each `Test.WebApp.Client` project, for both Core and Pro. These files are
in `.gitignore`. See [Tests.md](test/Tests.md) for details.

For sample applications, see the [GeoBlazor-Samples](https://github.com/dymaptic/GeoBlazor-Samples) repository.

## Contributing

Open an issue or pull request in the [GeoBlazor repository](https://github.com/dymaptic/GeoBlazor). The
[Developer Guide](../docs/DeveloperGuide.md) covers contributing to GeoBlazor, and the
[test automation guide](../test/dymaptic.GeoBlazor.Core.Test.Automation/README.md) covers browser testing with Playwright
and MSTest.
