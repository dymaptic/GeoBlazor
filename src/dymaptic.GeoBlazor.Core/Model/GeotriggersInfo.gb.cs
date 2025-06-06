// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.GeotriggersInfo.html">GeoBlazor Docs</a>
///     Information relating to a list of Geotriggers.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-GeotriggersInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Geotriggers">
///     A list of Geotriggers.
///     default null
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webdoc-GeotriggersInfo.html#geotriggers">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record GeotriggersInfo(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<Geotrigger>? Geotriggers = null);
