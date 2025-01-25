// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    The fields that record who adds or edits data in the feature service and when the edit is made.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class EditFieldsInfo : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public EditFieldsInfo()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="creationDateField">
    ///     The name of the field that stores the date and time the feature was created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="creatorField">
    ///     The name of the field that stores the name of the user who created the feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="editDateField">
    ///     The name of the field that stores the date and time the feature was last edited.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="editorField">
    ///     The name of the field that stores the name of the user who last edited the feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public EditFieldsInfo(
        string? creationDateField = null,
        string? creatorField = null,
        string? editDateField = null,
        string? editorField = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CreationDateField = creationDateField;
        CreatorField = creatorField;
        EditDateField = editDateField;
        EditorField = editorField;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The name of the field that stores the date and time the feature was created.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CreationDateField { get; set; }
    
    /// <summary>
    ///     The name of the field that stores the name of the user who created the feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CreatorField { get; set; }
    
    /// <summary>
    ///     The name of the field that stores the date and time the feature was last edited.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EditDateField { get; set; }
    
    /// <summary>
    ///     The name of the field that stores the name of the user who last edited the feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditFieldsInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EditorField { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the CreationDateField property.
    /// </summary>
    public async Task<string?> GetCreationDateField()
    {
        if (CoreJsModule is null)
        {
            return CreationDateField;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return CreationDateField;
        }

        // get the property value
#pragma warning disable BL0005
        CreationDateField = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "creationDateField");
#pragma warning restore BL0005
         ModifiedParameters[nameof(CreationDateField)] = CreationDateField;
        return CreationDateField;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the CreatorField property.
    /// </summary>
    public async Task<string?> GetCreatorField()
    {
        if (CoreJsModule is null)
        {
            return CreatorField;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return CreatorField;
        }

        // get the property value
#pragma warning disable BL0005
        CreatorField = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "creatorField");
#pragma warning restore BL0005
         ModifiedParameters[nameof(CreatorField)] = CreatorField;
        return CreatorField;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the EditDateField property.
    /// </summary>
    public async Task<string?> GetEditDateField()
    {
        if (CoreJsModule is null)
        {
            return EditDateField;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return EditDateField;
        }

        // get the property value
#pragma warning disable BL0005
        EditDateField = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "editDateField");
#pragma warning restore BL0005
         ModifiedParameters[nameof(EditDateField)] = EditDateField;
        return EditDateField;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the EditorField property.
    /// </summary>
    public async Task<string?> GetEditorField()
    {
        if (CoreJsModule is null)
        {
            return EditorField;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return EditorField;
        }

        // get the property value
#pragma warning disable BL0005
        EditorField = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "editorField");
#pragma warning restore BL0005
         ModifiedParameters[nameof(EditorField)] = EditorField;
        return EditorField;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the CreationDateField property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCreationDateField(string value)
    {
#pragma warning disable BL0005
        CreationDateField = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CreationDateField)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "creationDateField", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the CreatorField property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCreatorField(string value)
    {
#pragma warning disable BL0005
        CreatorField = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CreatorField)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "creatorField", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the EditDateField property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetEditDateField(string value)
    {
#pragma warning disable BL0005
        EditDateField = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(EditDateField)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "editDateField", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the EditorField property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetEditorField(string value)
    {
#pragma warning disable BL0005
        EditorField = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(EditorField)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "editorField", value);
    }
    
#endregion




}
