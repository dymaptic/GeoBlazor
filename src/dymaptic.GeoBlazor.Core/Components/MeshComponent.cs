namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class MeshComponent: IProtobufSerializable<MeshComponentSerializationRecord>
{
   // Add custom code to this file to override generated code
   /// <inheritdoc />
    public MeshComponentSerializationRecord ToProtobuf()
   {
       MeshComponentMaterialSerializationRecord? materialRecord = Material switch
       {
           MeshMaterialMetallicRoughness metallicRoughness => metallicRoughness.ToProtobuf(),
           MeshMaterial material => material.ToProtobuf(),
           _ => null
       };
       return new MeshComponentSerializationRecord(Faces,
           materialRecord, Name, Shading?.ToString().ToKebabCase());
   }
   
   /// <summary>
   ///     Asynchronously retrieve the current value of the Material property.
   /// </summary>
   [CodeGenerationIgnore]
   public async Task<IMeshComponentMaterial?> GetMaterial()
   {
       if (CoreJsModule is null)
       {
           return Material;
       }
        
       try 
       {
           JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
               "getJsComponent", CancellationTokenSource.Token, Id);
       }
       catch (JSException)
       {
           // this is expected if the component is not yet built
       }
        
       if (JsComponentReference is null)
       {
           return Material;
       }

       IMeshComponentMaterial? result = await JsComponentReference.InvokeAsync<IMeshComponentMaterial?>(
           "getMaterial", CancellationTokenSource.Token);
        
       if (result is not null)
       {
#pragma warning disable BL0005
           Material = result;
#pragma warning restore BL0005
           ModifiedParameters[nameof(Material)] = Material;
       }
         
       return Material;
   }
}