---
layout: page
title: "Writing Your Own JavaScript Extensions"
nav_order: 12
---

# Writing Your Own JavaScript Extensions

By writing a bit of JavaScript, you can unlock all the features of the ArcGIS Maps SDK for JavaScript, even if the features are not yet exposed in GeoBlazor. Of course, if there are features you would like to see supported in GeoBlazor, [please open a GitHub issue](https://github.com/dymaptic/GeoBlazor/issues). But sometimes it is important to not wait for a new release, or if you have a specific edge case. Occasionally, it can also be useful to write JS for better performance, especially in Blazor Server, if dealing with a fast-moving UI interaction.

## How to Write JavaScript Extensions

1. Create a `.js` file in your `wwwroot` folder or a subfolder.

`extensions.js`
```javascript
import {
    arcGisObjectRefs // you can also import other types
} from "../../dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js";

export function myCustomFunction(myValues, viewId) {
    let view = arcGisObjectRefs[viewId];
    // with this view, you can do anything supported in ArcGIS JS
}

```

2. Invoke this JS file as a module from Blazor

```csharp
IJSObjectReference module = 
    await JsRuntime.InvokeAsync<IJSObjectReference>("import", "extensions.js");
```

3. Invoke the function from Blazor

```csharp
await module.InvokeVoidAsync("myCustomFunction", myValue, View.Id);
```

For a full example, see https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/wwwroot/js/extensions.js 
and https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor