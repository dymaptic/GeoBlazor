namespace dymaptic.GeoBlazor.Core.Options;

public partial record BasemapLayerListCatalogOptions
{
   // Add custom code to this file to override generated code
   public DotNetObjectReference<BasemapLayerListCatalogOptions> DotNetOptionsReference => DotNetObjectReference.Create(this);
    
   public bool HasListItemCreatedHandler => ListItemCreatedFunction != null;
    
   [JSInvokable]
   public async Task<ListItem> OnListItemCreated(ListItem listItem)
   {
      if (ListItemCreatedFunction is null) return listItem;
      return await ListItemCreatedFunction.Invoke(listItem);
   }
}