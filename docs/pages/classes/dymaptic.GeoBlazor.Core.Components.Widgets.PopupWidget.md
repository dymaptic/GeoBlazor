---
layout: default
title: PopupWidget
parent: Classes
---
---
layout: default
title: PopupWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## PopupWidget Class

The Popup widget allows users to view content from feature attributes. Popups enhance web applications by providing  
users with a simple way to interact with and view attributes in a layer. They play an important role in relaying  
information to the user, which improves the storytelling capabilities of the application.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">  
    ArcGIS  
    API  
</a>

```csharp
public class PopupWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; PopupWidget

### Remarks
All Views contain a default popup. This popup can display generic content, which is set in its title and content  
properties. When content is set directly on the Popup instance it is not tied to a specific feature or layer.  
In most cases this module will not need to be loaded into your application because the view contains a default  
instance of popup.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Actions'></a>

## PopupWidget.Actions Property

Defines actions that may be executed by clicking the icon or image symbolizing them in the popup. By default, every  
popup has a zoom-to action styled with a magnifying glass icon. When this icon is clicked, the view zooms in four  
LODs and centers on the selected feature.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.ActionBase>? Actions { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Alignment'></a>

## PopupWidget.Alignment Property

Position of the popup in relation to the selected feature. The default behavior is to display above the feature and  
adjust if not enough room. If needing to explicitly control where the popup displays in relation to the feature,  
choose an option besides auto.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Widgets.PopupAlignment> Alignment { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PopupAlignment](dymaptic.GeoBlazor.Core.Components.Widgets.PopupAlignment.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupAlignment')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.AutoCloseEnabled'></a>

## PopupWidget.AutoCloseEnabled Property

This closes the popup when the View camera or Viewpoint changes.

```csharp
public System.Nullable<bool> AutoCloseEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.AutoOpenEnabled'></a>

## PopupWidget.AutoOpenEnabled Property

This property indicates to the Popup that it needs to allow or disallow the click event propagation. Use  
view.popup.autoOpenEnabled = false; when needing to stop the click event propagation.  
DefaultValue: true

```csharp
public System.Nullable<bool> AutoOpenEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Collapsed'></a>

## PopupWidget.Collapsed Property

Indicates whether the popup displays its content. If true, only the header displays.

```csharp
public System.Nullable<bool> Collapsed { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.CollapseEnabled'></a>

## PopupWidget.CollapseEnabled Property

Indicates whether to enable collapse functionality for the popup.  
DefaultValue: true

```csharp
public System.Nullable<bool> CollapseEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.DefaultPopupTemplateEnabled'></a>

## PopupWidget.DefaultPopupTemplateEnabled Property

Enables automatic creation of a popup template for layers that have popups enabled but no popupTemplate defined.  
Automatic popup templates are supported for layers that support the createPopupTemplate method. (Supported for  
FeatureLayer, GeoJSONLayer, OGCFeatureLayer, SceneLayer, CSVLayer, PointCloudLayer, StreamLayer, and ImageryLayer).

```csharp
public System.Nullable<bool> DefaultPopupTemplateEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.DockEnabled'></a>

## PopupWidget.DockEnabled Property

Indicates whether the placement of the popup is docked to the side of the view.  
Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.  
When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned  
to it. Rather it is attached to a side, the top, or the bottom of the view.  
See [DockOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.DockOptions 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.DockOptions') to override default options related to docking the popup.

```csharp
public System.Nullable<bool> DockEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.DockOptions'></a>

## PopupWidget.DockOptions Property

Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.  
When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned  
to it. Rather it is placed in one of the corners of the view or to the top or bottom of it. This property allows  
the developer to set various options for docking the popup.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions? DockOptions { get; set; }
```

#### Property Value
[PopupDockOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Features'></a>

## PopupWidget.Features Property

An array of features associated with the popup. Each graphic in this array must have a valid PopupTemplate set.  
They may share the same PopupTemplate or have unique PopupTemplates depending on their attributes. The content and  
title of the popup is set based on the content and title properties of each graphic's respective PopupTemplate.  
When more than one graphic exists in this array, the current content of the Popup is set based on the value of the  
selected feature.  
This value is null if no features are associated with the popup.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> Features { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.HeadingLevel'></a>

## PopupWidget.HeadingLevel Property

Indicates the heading level to use for the title of the popup. By default, the title is rendered as a level 2  
heading (e.g. <h2>Popup title</h2>). Depending on the widget's placement in your app, you may need to adjust this  
heading for proper semantics. This is important for meeting accessibility standards.  
DefaultValue:2

```csharp
public System.Nullable<int> HeadingLevel { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.HighlightEnabled'></a>

## PopupWidget.HighlightEnabled Property

Highlight the selected popup feature using the highlightOptions set on the MapView or the highlightOptions set on  
the SceneView.

```csharp
public System.Nullable<bool> HighlightEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Label'></a>

## PopupWidget.Label Property

The widget's default label.

```csharp
public string? Label { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Location'></a>

## PopupWidget.Location Property

Point used to position the popup. This is automatically set when viewing the popup by selecting a feature. If using  
the Popup to display content not related to features in the map, such as the results from a task, then you must set  
this property before making the popup visible to the user.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point? Location { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.MaxInlineActions'></a>

## PopupWidget.MaxInlineActions Property

Defines the maximum icons displayed at one time in the action area.  
DefaultValue: 3

```csharp
public System.Nullable<int> MaxInlineActions { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.SpinnerEnabled'></a>

## PopupWidget.SpinnerEnabled Property

Indicates whether to display a spinner at the popup location prior to its display when it has pending promises.

```csharp
public System.Nullable<bool> SpinnerEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.StringContent'></a>

## PopupWidget.StringContent Property

The html string content of the popup. When set directly on the Popup, this content is static and cannot use fields  
to set content templates. To set a template for the content based on field or attribute names, see  
[Content](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html#dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content').

```csharp
public string? StringContent { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Title'></a>

## PopupWidget.Title Property

The title of the popup. This can be set generically on the popup no matter the features that are selected. If the  
selected feature has a PopupTemplate, then the title set in the corresponding template is used here.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.VisibleElements'></a>

## PopupWidget.VisibleElements Property

The visible elements that are displayed within the widget. This property provides the ability to turn individual  
elements of the widget's display on/off.

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements? VisibleElements { get; set; }
```

#### Property Value
[PopupVisibleElements](dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.WidgetContent'></a>

## PopupWidget.WidgetContent Property

The widget content of the popup. When set directly on the Popup, this content is static and cannot use fields to  
set content templates. To set a template for the content based on field or attribute names, see  
[Content](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html#dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.Content').

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.Widget? WidgetContent { get; set; }
```

#### Property Value
[Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.WidgetType'></a>

## PopupWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Clear()'></a>

## PopupWidget.Clear() Method

Removes promises, features, content, title and location from the Popup.

```csharp
public System.Threading.Tasks.Task Clear();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Close()'></a>

## PopupWidget.Close() Method

Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly  
setting the visible property to false.

```csharp
public System.Threading.Tasks.Task Close();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.FetchFeatures()'></a>

## PopupWidget.FetchFeatures() Method

Use this method to return feature(s) at a given screen location. These features are fetched from all of the  
LayerViews in the view. In order to use this, a layer must already have an associated PopupTemplate and have its  
popupEnabled. These features can then be used within a custom Popup or Feature widget experience.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.Graphic[]> FetchFeatures();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.GetFeatureCount()'></a>

## PopupWidget.GetFeatureCount() Method

The number of selected features available to the popup.

```csharp
public System.Threading.Tasks.Task<int> GetFeatureCount();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.GetSelectedFeature()'></a>

## PopupWidget.GetSelectedFeature() Method

The selected feature accessed by the popup. The content of the Popup is determined based on the PopupTemplate  
assigned to this feature.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> GetSelectedFeature();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.GetSelectedFeatureIndex()'></a>

## PopupWidget.GetSelectedFeatureIndex() Method

Index of the feature that is selected. When features are set, the first index is automatically selected.

```csharp
public System.Threading.Tasks.Task<int> GetSelectedFeatureIndex();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.GetVisibility()'></a>

## PopupWidget.GetVisibility() Method

Index of the feature that is selected. When features are set, the first index is automatically selected.

```csharp
public System.Threading.Tasks.Task<bool> GetVisibility();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.OnTriggerAction(string)'></a>

## PopupWidget.OnTriggerAction(string) Method

JS-invokable method for triggering actions.

```csharp
public System.Threading.Tasks.Task OnTriggerAction(string actionId);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.OnTriggerAction(string).actionId'></a>

`actionId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The action ID.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.Open()'></a>

## PopupWidget.Open() Method

Opens the popup at the given location with content defined either explicitly with content or driven from the  
PopupTemplate of input features. This method sets the popup's visible property to true. Users can alternatively  
open the popup by directly setting the visible property to true.

```csharp
public System.Threading.Tasks.Task Open();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## PopupWidget.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.SetContent(string)'></a>

## PopupWidget.SetContent(string) Method

Sets the string content of the popup.

```csharp
public System.Threading.Tasks.Task SetContent(string stringContent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.SetContent(string).stringContent'></a>

`stringContent` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## PopupWidget.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupWidget.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.

