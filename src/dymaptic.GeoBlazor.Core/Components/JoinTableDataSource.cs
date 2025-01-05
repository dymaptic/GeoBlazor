namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The result of an on-the-fly join operation at runtime. Nested joins are supported. To use nested joins, set either leftTableSource or rightTableSource to join-table.
///     <a target="_blank" href="The result of an on-the-fly join operation at runtime. Nested joins are supported. To use nested joins, set either leftTableSource or rightTableSource to join-table.">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class JoinTableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public JoinTableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new JoinTableDataSource in code with parameters.
    /// </summary>
    /// <param name = "leftTableKey">
    ///     The field name used for joining or matching records in the left table to records in the right table.
    /// </param>
    /// <param name = "rightTableKey">
    ///     The field name used for joining or matching records in the right table to records in the left table.
    /// </param>
    /// <param name = "joinType">
    ///     The type of join that will be performed.
    /// </param>
    /// <param name = "leftTableSource">
    ///     The left table for joining to the right table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </param>
    /// <param name = "rightTableSource">
    ///     The right table for joining to the left table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </param>
    public JoinTableDataSource(string leftTableKey, string rightTableKey, DynamicJoinType joinType, DynamicLayer leftTableSource, DynamicLayer rightTableSource)
    {
#pragma warning disable BL0005 // Set parameter or member default value.

        LeftTableKey = leftTableKey;
        RightTableKey = rightTableKey;
        JoinType = joinType;
        LeftTableSource = leftTableSource;
        RightTableSource = rightTableSource;
#pragma warning restore BL0005 // Set parameter or member default value.

    }

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

    /// <summary>
    ///     The left table for joining to the right table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? LeftTableSource { get; set; }

    /// <summary>
    ///     The right table for joining to the left table source. This can either be a dynamic map layer or a dynamic data layer. The dynamic data layer may contain another join data source used for nested joining.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? RightTableSource { get; set; }

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

    /// <inheritdoc/>
    internal override void ValidateRequiredChildren()
    {
        LeftTableSource?.ValidateRequiredChildren();
        RightTableSource?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}


