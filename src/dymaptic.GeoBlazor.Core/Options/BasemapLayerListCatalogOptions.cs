namespace dymaptic.GeoBlazor.Core.Options;

public partial record BasemapLayerListCatalogOptions
{
   /// <summary>
   ///    Identifies whether the options component has a <see cref="ListItemCreatedFunction"/>.
   /// </summary>
   public bool HasListItemCreatedHandler => ListItemCreatedFunction != null;
    
   /// <summary>
   ///    Callback from JavaScript to C# when a list item is created.
   /// </summary>
   [JSInvokable]
   public async Task<ListItem> OnListItemCreated(ListItem listItem)
   {
      if (ListItemCreatedFunction is null) return listItem;
      return await ListItemCreatedFunction.Invoke(listItem);
   }
}