namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     The root interface for Razor Component classes that all GeoBlazor components derive from.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IMapComponent>))]
[CodeGenerationIgnore]
public interface IMapComponent
{
    /// <summary>
    ///     A unique identifier, used to track components across .NET and JavaScript.
    /// </summary>
    Guid Id { get; internal set; }
    
    /// <summary>
    ///     The parent MapComponent of this component.
    /// </summary>
    MapComponent? Parent { get; internal set; }
    
    /// <summary>
    ///     The reference to the entry point geoBlazorCore.js from .NET
    /// </summary>
    IJSObjectReference? CoreJsModule { get; internal set; }

    /// <summary>
    ///     The reference to the entry point geoBlazorPro.js from .NET
    /// </summary>
    IJSObjectReference? ProJsModule { get; }

    /// <summary>
    /// ///     The parent <see cref="View" /> of the current component.
    /// </summary>
    MapView? View { get; set; }

    /// <summary>
    ///     The ID of the parent <see cref="View" /> of the current component.
    /// </summary>
    Guid? ViewId { get; set; }

    /// <summary>
    ///     The relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    Layer? Layer { get; set; }

    /// <summary>
    ///     The GeoBlazor Id of the relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    Guid? LayerId { get; set; }

    /// <summary>
    ///     When a <see cref="View" /> is prepared to render, this will check to make sure that all properties with the <see cref="RequiredPropertyAttribute" /> are provided.
    /// </summary>
    void ValidateRequiredChildren();
    
    /// <summary>
    ///     Validates source-generated child components.
    /// </summary>
    void ValidateRequiredGeneratedChildren();
    
    /// <summary>
    ///     Implements the `IAsyncDisposable` pattern.
    /// </summary>
    ValueTask DisposeAsync();

    /// <summary>
    ///     For internal use only. Populates necessary references to JS-deserialized child components.
    /// </summary>
    void UpdateGeoBlazorReferences(IJSObjectReference coreJsModule,
        IJSObjectReference? proJsModule,
        MapView? view, IMapComponent? parent, Layer? layer, int depth = 0, HashSet<object>? visited = null);
}