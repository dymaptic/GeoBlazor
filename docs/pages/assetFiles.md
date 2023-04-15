---
layout: page
title: Asset Files
nav_order: 9
---

# Asset Files

Asset files, by default, will load from the `dymaptic.GeoBlazor.Core` library at `/_content/dymaptic.GeoBlazor.Core/assets`.

If for some reason you want to bundle your own assets, you would change this by adding an environment variable or setting
in `appsettings.json` of `"ArcGISAssetsPath": "...your/web/assets/url"`.

Note that this `ArcGISAssetsPath` can also be a full URL if your assets are hosted on your Enterprise portal, for example. 
Most people won't need to change this, but [here are the docs for this property](https://developers.arcgis.com/javascript/latest/es-modules/#working-with-assets).

You should also consider adding the following line to `index.html` or `_Layout.cshtml`, which helps ensure that all paths are relative to the root.

```html
<base href="/"/>
```