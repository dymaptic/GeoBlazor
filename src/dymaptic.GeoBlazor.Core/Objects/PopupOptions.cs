using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public class PopupOptions
{
    public PopupDockOptions DockOptions { get; set; } = new();

    public PopupVisibleElements VisibleElements { get; set; } = new();
}

public class PopupDockOptions
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ButtonEnabled { get; set; }
}

public class PopupVisibleElements
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseButton { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FeatureNavigation { get; set; }
}