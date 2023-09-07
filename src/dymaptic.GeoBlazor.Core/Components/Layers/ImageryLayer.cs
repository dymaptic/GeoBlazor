using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Represents a dynamic image service resource as a layer. An ImageryLayer retrieves and displays data from dynamic image services. An image service supports
///     accessing the mosaicked image, its catalog, and the individual rasters in the catalog. An image service supports dynamic access and tiled access. 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class ImageryLayer : Layer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "imagery";

    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public ImageryLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The absolute URL of the REST endpoint of the layer, non-spatial table or service
    /// </param>  
    /// <param name="portalItem">
    ///     The <see cref="PortalItem" /> from which the layer is loaded.
    /// </param>
    /// <param name="renderer">
    ///     An abstract base class that implements a variety of imagery renderers.
    /// </param>

    public ImageryLayer(string? url = null, PortalItem? portalItem = null, ImageryRenderer? renderer = null
        ) 
    {
        if (url is null && portalItem is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(ImageryLayer),
                new[] { nameof(Url), nameof(PortalItem) });
        }
        Renderer = renderer;
        Url = url;
        PortalItem = portalItem;

    }

    /// <summary>
    ///     The url for the Imagery Layer source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem))]
    public string? Url { get; set; }

    /// <summary>
    ///     The portal item for the Imagery Layer source data.
    /// </summary>
    [RequiredProperty(nameof(Url))]
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     An interface that implements the various imagery renderers.
    /// </summary>
    public ImageryRenderer? Renderer { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    LayerChanged = true;
                }
                break;
            case ImageryRenderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    LayerChanged = true;
                }
                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem _:
                PortalItem = null;
                LayerChanged = true;
                break;
            case ImageryRenderer _:
                Renderer = null;
                LayerChanged = true;
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
        Renderer?.ValidateRequiredChildren();
    }
}

/// <summary>
/// The format of the data sent by the server.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ImageFormat>))]
public enum ImageFormat
{
#pragma warning disable CS1591
    Png,
    Png8,
    Png24,
    Png32,
    Jpg,
    Bmp,
    Gif,
    Jpgpng,
    Lerc,
    Tiff
#pragma warning restore CS1591
}
