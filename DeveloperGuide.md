# Developer Documentation
This document is intended for developers and maintainers of the GeoBlazor source code. The guidelines are for new 
development and refactoring of existing code, but may not be adhered to by all existing code.

## General Goals
- Support end user use of ArcGIS tools without having to write JavaScript
- Support components as both Razor markup elements and C# code object
- Support idiomatic C# coding patterns
- Maintain a close relationship between ArcGIS and GeoBlazor architecture to allow easier maintenance, updates, and documentation

## Understanding The GeoBlazor (and Blazor) Lifecycle
Blazor components are built around the concept of automatic binding and updating when C# properties and variables change.
Each time Blazor detects a change, it will re-render the component and all of its child-components, and then update the client html.
The Blazor component lifecycle method `OnAfterRender` and `OnAfterRenderAsync` can thus be triggered many times during a
component's lifetime, and are usually called _at least_ twice on startup. Similarly, the method `OnParametersSet` and
`OnParametersSetAsync` will be called every time Blazor detects a change in a component parameter (which also then triggers a render).

Unlike normal Blazor components, however, GeoBlazor components are not being rendered to HTML. Instead, they are being passed
as data to a JavaScript layer, where they are used to generate the relevant ArcGIS objects. As you can imagine, calling the
same JavaScript to render in ArcGIS repeatedly would be a bad idea. Therefore, GeoBlazor has checks in place to guarantee
that a map is only rendered once, and then on actual component changes. This creates a few limitations and new capabilities
that normal Blazor components do not have.

### GeoBlazor Component Limitations
- Synchronous property setters will not automatically cause a map to update. This is because all JavaScript calls (at
  least those that support all Blazor modes) are asynchronous, and there is no safe way to trigger an async method from
  a synchronous setter. Instead, the suggested pattern is to implement asynchronous `Set{PropertyName}()` methods that
  can call a custom JS function to update the value.
- Similarly, property getters do not automatically load the latest value from JavaScript. If the property is expected to
  be updated regularly and "read", you should implement an asynchronous `Get{PropertyName}()` method to load the value
  from JavaScript.
- Some Blazor parameters are only read once on the first render, and will not auto-bind to value changes like other components.
  Users will have to be guided to use the async `Set` methods to update properties after initial render. For example,
  we do try to support binding in the top-level `MapView` parameters such as `Latitude`, `Longitude`, and `Zoom`. However,
  once a user zooms or scrolls the map manually, we cannot support the binding anymore, because the map would always "snap"
  back to its original position, so the binding stops being read after manual map manipulation.
- GeoBlazor components must be nested in their proper parent components. Methods like `RegisterChildComponent` should be
  implemented for each child component, and `[RequiredParameter]` should be used to enforce a parameter that needs to be set
  by the user. This approach should provide clear error messages if the user places a component in the wrong place or forgets
  a parameter.

### GeoBlazor Component Capabilities
- Unlike other Blazor components. GeoBlazor MapComponents can be created in C# code as well as in markup. To avoid the
  `BL0005:Component parameter should not be set outside of its component` warning, we create two constructors for each
  component, one empty constructor for razor markup, and another one that sets all properties and uses
  `#pragma warning disable BL0005` to silence the warning.

## MapComponents
- A `MapComponent` is a Razor (aka Blazor) Component that can be declared in Razor markup. For example, `MapView`, 
  `Map`, `FeatureLayer`, and `Graphic` are all `MapComponent`s.
- `MapComponent`s are usually 1-1 with ArcGIS JavaScript classes.
- `MapComponent`s, with a few top-level exceptions (e.g., `MapView`, `Map`), can also be declared in C# code.
- There should always be two constructors, an empty one for razor, and one that sets all public properties that should be used
  when creating the component in C#.
- Properties should never be set in C# _after_ the component has been rendered to JavaScript.
  The following patterns should be followed and enforced as much as possible:
  - Define the property in razor markup, either as a `Parameter` or as a child component
  - Use the constructor to set all properties
  - Add an async `Set{PropertyName}` method, which calls to JavaScript to update the value (this is not needed for every property, just commonly updated ones)
- Properties with simple/primitive types (e.g. int, double, string, bool, enum) should be marked as `[Parameter]`s for Blazor. 
  This will also generate a warning if a user tries to set these properties by hand in code after the component is rendered.
- Properties with object types should *also* inherit from `MapComponent`, so they can be written as child tags in razor markup.
- MapComponent properties should have `{ get; private set; }` to force folks to use one of the patterns described above.
- If there are any `MapComponent` properties, `RegisterChildComponent`, `UnregisterChildComponent`, and 
  `ValidateRequiredChildred` should be implemented and handle all child `MapComponent` properties

## JSON Serialization
- All `enum` types should be marked with the `[JsonConverter(typeof(EnumToKebabCaseStringConverter<{YourType}>))]` attribute
- Inherited Types sometimes require custom `JsonConverter` implementations to avoid serializing as the base type. See `LayerConverter` as an example.
- If you want to avoid passing `null` properties, mark properties with `[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]`.
  However, this will also be dealt with in the next section about `Converting GeoBlazor Objects to ArcGIS`.

## Converting GeoBlazor Objects to ArcGIS
- Simple/primitive values can be easily copied from a C# object to an ArcGIS object. However, complex objects tend to fail, for several reasons outlined below.
- Setting a value in an ArcGIS object to `null` when it expects a value can cause it to fail silently. There are several patterns to avoid this.
  - If setting the value in a constructor, use `?? undefined` to avoid setting the value to `null`.
  ```js
    let template = new PopupTemplate({
        title: popupTemplateObject.title ?? undefined,
        content: content ?? undefined,
        outFields: popupTemplateObject.outFields ?? undefined,
        overwriteActions: popupTemplateObject.overwriteActions ?? false,
        returnGeometry: popupTemplateObject.returnGeometry ?? false
    });
  ```
  - Check the for `undefined` and `null` before setting the value.
  ```js
    if (popupTemplateObject.title !== undefined && popupTemplateObject.title !== null) {
        template.title = popupTemplateObject.title;
    }
  ```
  - Several of the TypeScript files have a shorthand function for this called `hasValue`.
  ```js
    if (hasValue(popupTemplateObject.title)) {
        template.title = popupTemplateObject.title;
    }
  ```
- The GeoBlazor C# types are serialized with a `Guid` `id` property. This is used to store and find references between
  the two languages. However, this may also be causing some issues when simply "setting" a dotnet object to an ArcGIS object.
  ArcGIS _tries_ to auto-cast objects, but unknown properties could cause it to fail.
- The suggested pattern for creating a complex ArcGIS object is to define a `buildJs...` function in `jsBuilder.ts`. This
  gives you a place to implement the null checks and other conversion logic necessary. You may have to use several nested `buildJs...` functions.

## Converting ArcGIS Objects to GeoBlazor Objects
- While it is not as common, there are times when you need to convert an ArcGIS object to a GeoBlazor object. This is usually
  done when an event is fired from the JavaScript side, and you need to pass the object back to C#.
- The JsonSerializer _may_ handle the ArcGIS object correctly
- If not, you can define a `buildDotNet...` function in `dotNetBuilder.ts` to do any necessary conversions.

## The JavaScript Wrapper Pattern
- In order to call methods on an ArcGIS object, you need a reference to the JS object. However, as described above, we
  often need a "shim" layer in which to cast arguments from a GeoBlazor object to an ArcGIS object. For objects like `Layers`
  and `Widgets`, this is often done by providing a `wrapper`. This is a separate TypeScript class file that has a reference
  to the original JS object, and replicates the method calls while allows for building custom types. See `featureLayerWrapper.ts` for an example.
- If an object has no functions that we want to support, or if the functions only take primitive types, you do not really need a wrapper.

## Development Process
- Identify a feature in the ArcGIS JavaScript SDK that you want to support in GeoBlazor
- If there is no related gissue, create one and assign it to yourself
- Create a new branch for your work with the pattern `feature/{gissue-number}_{short-description}`
- Find a relevant sample from the ArcGIS JavaScript SDK, if one exists
- Create a new sample page in `dymaptic.GeoBlazor.Core.Samples.Shared/Pages`. Use the same header pattern as other samples
  - The links in the sample header should point to a) the JS sample page and b) the data source (e.g., feature service) used, if available
- Implement the necessary C# classes and methods to support the feature
- Implement TypeScript functions and classes if necessary for your C# classes to call and use. See the `Widgets` and `Layers` details below for more examples
- If possible, flesh out all properties and methods from ArcGIS classes in your C# implementation, even if they are not directly used in the sample
- Write unit tests in `dymaptic.GeoBlazor.Core.Tests.Blazor.Shared` to test your new classes and methods

### Adding a New Layer Type
- Create a new C# class in the `dymaptic.GeoBlazor.Core/Components/Layers` folder that inherits from `Layer`.
- Implement the `LayerType` property. The type value should match the layer `type` value in ArcGIS.
  ```csharp
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "layer-type";
  ```
- Add your new layer type to `LayerConverter` for serialization.
- Implement all properties from the ArcGIS Layer class. Use the `MapComponents` rules outlined above.
- Add your layer to the switch statement in the `createLayer` function of `arcGisJsInterop.ts`. Use the `Converting GeoBlazor Objects to ArcGIS` rules outlined above.
- If the layer has methods that we want to support, create a `wrapper` class for it. See `The JavaScript Wrapper Pattern` above.
- Create a new Layer samples page in `dymaptic.GeoBlazor.Core.Samples.Shared/Pages`. Also add to the `NavMenu.razor`.
- Create a new unit test in `dymaptic.GeoBlazor.Core.Tests.Blazor.Shared/Components/LayerTests.razor`.

### Adding a New Widget
- Create a new C# class in the `dymaptic.GeoBlazor.Core/Components/Widgets` folder that inherits from `Widget`.
- Implement the `WidgetType` property. The type value should match the widget `type` value in ArcGIS.
  ```csharp
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "widget-type";
  ```
- Add your widget to the switch statement in the `createWidget` function of `arcGisJsInterop.ts`. Use the `Converting GeoBlazor Objects to ArcGIS` rules outlined above.
- If the widget has methods that we want to support, create a `wrapper` class for it. See `The JavaScript Wrapper Pattern` above.
- Create a new Widget samples page in `dymaptic.GeoBlazor.Core.Samples.Shared/Pages`. Also add to the `NavMenu.razor`.
- Alternatively, for simple widgets, you can add them to the `Widgets.razor` sample.
- Create a new unit test in `dymaptic.GeoBlazor.Core.Tests.Blazor.Shared/Components/WidgetTests.razor`.