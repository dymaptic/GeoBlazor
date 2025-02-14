namespace dymaptic.GeoBlazor.Core.Components;

public partial class JoinTableDataSource : DynamicDataSource
{


    /// <inheritdoc/>
    public override string Type => "join-table";

    /// <summary>
    ///     The field name used for joining or matching records in the left table to records in the right table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LeftTableKey { get; set; }

    /// <summary>
    ///     The field name used for joining or matching records in the right table to records in the left table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RightTableKey { get; set; }

    /// <summary>
    ///     The type of join that will be performed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicJoinType? JoinType { get; set; }


    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DynamicLayer dynamicLayer:
                if (LeftTableSource is null)
                {
                    LeftTableSource = dynamicLayer;
                }
                else
                {
                    RightTableSource = dynamicLayer;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DynamicLayer dynamicLayer:
                if (dynamicLayer.Equals(LeftTableSource))
                {
                    LeftTableSource = null;
                }
                else
                {
                    RightTableSource = null;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

}


