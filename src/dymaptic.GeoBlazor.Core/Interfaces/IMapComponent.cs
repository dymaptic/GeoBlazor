namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     An interface for all map components.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IMapComponent>))]
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
    ///     The parent <see cref="MapView" /> of the current component.
    /// </summary>
    MapView? View { get; internal set; }
    
    /// <summary>
    ///     The relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    Layer? Layer { get; internal set; }

    /// <summary>
    ///     When a <see cref="MapView" /> is prepared to render, this will check to make sure that all properties with the <see cref="RequiredPropertyAttribute" /> are provided.
    /// </summary>
    /// <exception cref="MissingRequiredChildElementException">
    ///     The consumer needs to provide the missing child component
    /// </exception>
    /// <exception cref="MissingRequiredOptionsChildElementException">
    ///     The consumer needs to provide ONE of the options of child components
    /// </exception>
    void ValidateRequiredChildren();
    
    /// <summary>
    ///     Validates source-generated child components.
    /// </summary>
    void ValidateRequiredGeneratedChildren();
    
    /// <summary>
    ///     Implements the `IAsyncDisposable` pattern.
    /// </summary>
    ValueTask DisposeAsync();
}