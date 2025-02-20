namespace dymaptic.GeoBlazor.Core.Options;

public partial record BasemapLayerListCatalogOptions
{
   public bool HasListItemCreatedHandler => ListItemCreatedFunction != null;
    
   [JSInvokable]
   public async Task<ListItem> OnListItemCreated(ListItem listItem)
   {
      if (ListItemCreatedFunction is null) return listItem;
      return await ListItemCreatedFunction.Invoke(listItem);
   }
}