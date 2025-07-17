# GeoBlazor Bundled Assets

This package provides bundled JavaScript assets for [GeoBlazor](https://geoblazor.com), a GIS Component Library and SDK for building interactive maps in Blazor, powered by ArcGIS.

## Overview

GeoBlazor has transitioned to using hosted CDN assets to reduce package size and build time. However, if you prefer to continue using bundled assets as in previous versions, this package provides that functionality.

## Features

- Self-contained JavaScript assets for GeoBlazor
- No external CDN dependencies required
- Compatible with offline or restricted network environments
- Includes ArcGIS API for JavaScript components
- Calcite Components integration

## Installation

Install the package via NuGet Package Manager:

```bash
dotnet add package dymaptic.GeoBlazor.BundledAssets
```

Or via Package Manager Console:

```powershell
Install-Package dymaptic.GeoBlazor.BundledAssets
```

## Usage

1. Install both the main GeoBlazor.Core package and this BundledAssets package
2. The bundled assets will be automatically included in your project
3. No additional configuration is required - the assets will be used instead of CDN resources

## Dependencies

This package includes bundled versions of:
- ArcGIS API for JavaScript (v4.33.8)
- ArcGIS Map Components (v4.33.8)
- Calcite Components (v3.2.1)

## When to Use This Package

Consider using this package if you:
- Need to work in offline or air-gapped environments
- Have strict security requirements that prevent CDN usage
- Want to ensure consistent asset versions
- Prefer self-hosted resources for performance or reliability reasons

## License

MIT License - see the main GeoBlazor repository for details.

## Support

For questions, issues, or support:
- Visit: [https://geoblazor.com](https://geoblazor.com)
- Email: geoblazor@dymaptic.com
- Repository: [https://github.com/dymaptic/GeoBlazor](https://github.com/dymaptic/GeoBlazor)

## Related Packages

- [dymaptic.GeoBlazor.Core](https://www.nuget.org/packages/dymaptic.GeoBlazor.Core/) - Main GeoBlazor library
- [dymaptic.GeoBlazor.Pro](https://www.nuget.org/packages/dymaptic.GeoBlazor.Pro/) - Professional features and extensions

---

**Note**: If you don't have specific requirements for bundled assets, we recommend using the main GeoBlazor.Core package with CDN assets for optimal performance and smaller package sizes.
