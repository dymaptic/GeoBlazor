# Developer Documentation
This document is intended for developers and maintainers of the GeoBlazor source code. The guidelines are for new 
development and refactoring of existing code, but may not be adhered to by all existing code.

## MapComponents
- A `MapComponent` is a Razor (aka Blazor) Component that can be declared in Razor markup. For example, `MapView`, 
  `Map`, `FeatureLayer`, and `Graphic` are all `MapComponent`s.
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