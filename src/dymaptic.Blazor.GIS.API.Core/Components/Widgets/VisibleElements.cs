using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Widgets;

public class VisibleElements : MapComponent
{
    public CreateTools? CreateTools { get; set; }

    public SelectionTools? SelectionTools { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SettingsMenu { get; set; }
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UndoRedoMenu { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CreateTools createTools:
                if (!((Object)createTools).Equals(CreateTools))
                {
                    CreateTools = createTools;
                    await UpdateComponent();
                }

                break;
            case SelectionTools selectionTools:
                if (!((Object)selectionTools).Equals(SelectionTools))
                {
                    SelectionTools = selectionTools;
                    await UpdateComponent();
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CreateTools _:
                CreateTools = null;
                await UpdateComponent();

                break;
            case SelectionTools _:
                SelectionTools = null;
                await UpdateComponent();

                break;
        }
    }
}

public class CreateTools : MapComponent
{
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Point { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Circle { get; set; }
}

public class SelectionTools : MapComponent
{
    [Parameter]
    [JsonPropertyName("lasso-selection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LassoSelection { get; set; }
    [Parameter]
    [JsonPropertyName("rectangle-selection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RectangleSelection { get; set; }
}