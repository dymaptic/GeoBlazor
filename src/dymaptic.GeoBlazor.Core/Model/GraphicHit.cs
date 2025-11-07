namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Object specification for the graphic hit result returned in HitTestResult of the hitTest() method.
/// </summary>
/// <param name = "Graphic">
///     A graphic representing a feature in the view that intersects the input screen coordinates. If the graphic comes
///     from a layer with an applied Renderer, then the symbol property will be empty. Other properties may be empty based
///     on the context in which the graphic is fetched. If the result comes from a VectorTileLayer then a static graphic is
///     returned with two attributes: layerId and layerName. These correspond to the name and id of the style-layer in the
///     vector tile style.
/// </param>
/// <param name = "LayerId">
///     The GeoBlazor Id for the layer that the graphic belongs to.
/// </param>
/// <param name = "MapPoint">
///     The point geometry in the spatial reference of the view corresponding with the input screen coordinates.
/// </param>
public record GraphicHit(Graphic Graphic, Guid? LayerId, Point MapPoint) : ViewHit("graphic", MapPoint)
{
    public override ViewHitSerializationRecord ToProtobuf()
    {
        return new ViewHitSerializationRecord(Type, MapPoint.ToProtobuf(), 
            Graphic.ToProtobuf(), LayerId?.ToString());
    }
}

