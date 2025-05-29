namespace dymaptic.GeoBlazor.Core.Components;

public partial class TimeExtent: MapComponent, IEquatable<TimeExtent>
{
    // for some reason, the new TimeExtent definition in the ArcGIS defs is missing these two methods, but they are still in the docs.
#region Public Methods

    /// <summary>
    ///     Returns the time extent resulting from the intersection of a given time extent and parsed time extent.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeExtent.html#intersection">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="timeExtent">
    ///     The time extent to be intersected with the time extent
    ///     on which <code>intersection()</code> is being called on.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<TimeExtent?> Intersection(TimeExtent timeExtent)
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<TimeExtent?>(
            "intersection", 
            CancellationTokenSource.Token,
            timeExtent);
    }
    
    /// <summary>
    ///     Returns the time extent resulting from the union of the current time extent and a given time extent.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-TimeExtent.html#union">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="timeExtent">
    ///     The time extent to be unioned with.
    /// </param>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<TimeExtent?> Union(TimeExtent timeExtent)
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<TimeExtent?>(
            "union", 
            CancellationTokenSource.Token,
            timeExtent);
    }
    
#endregion

    
    /// <inheritdoc />
    public bool Equals(TimeExtent? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Nullable.Equals(End, other.End) && Nullable.Equals(Start, other.Start);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((TimeExtent)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(End, Start);
    }

    /// <summary>
    ///     Overrides the == operator to compare two TimeExtent objects.
    /// </summary>
    public static bool operator ==(TimeExtent? left, TimeExtent? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Overrides the != operator to compare two TimeExtent objects.
    /// </summary>
    public static bool operator !=(TimeExtent? left, TimeExtent? right)
    {
        return !Equals(left, right);
    }
}