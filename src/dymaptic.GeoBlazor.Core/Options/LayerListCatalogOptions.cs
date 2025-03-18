namespace dymaptic.GeoBlazor.Core.Options;

public partial record LayerListCatalogOptions
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///    Identifies if the Options object has a <see cref="ListItemCreatedFunction"/>.
   /// </summary>
   public bool HasListItemCreatedHandler => ListItemCreatedFunction != null;
    
   /// <summary>
   ///    JavaScript callback function that is called when a list item is created.
   /// </summary>
   [JSInvokable]
   public async Task<ListItem> OnListItemCreated(ListItem listItem)
   {
      if (ListItemCreatedFunction is null) return listItem;
      return await ListItemCreatedFunction.Invoke(listItem);
   }

}