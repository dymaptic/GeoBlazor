namespace dymaptic.GeoBlazor.Core.Components;

public partial class MeshVertexAttributes: IProtobufSerializable<MeshVertexAttributesSerializationRecord>
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     Asynchronously retrieve the current value of the Color property.
   /// </summary>
   [CodeGenerationIgnore]
   public async Task<byte[]?> GetColor()
   {
       if (CoreJsModule is null)
       {
           return Color;
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
           return Color;
       }

       // get the property value
       IJSStreamReference? result = await JsComponentReference!.InvokeAsync<IJSStreamReference?>("getProperty",
           CancellationTokenSource.Token, "color");
       if (result is not null)
       {
           await using Stream stream = await result.OpenReadStreamAsync(1_000_000_000);
           await using MemoryStream ms = new MemoryStream();
           await stream.CopyToAsync(ms);
#pragma warning disable BL0005
           Color = ms.ToArray();
#pragma warning restore BL0005
           ModifiedParameters[nameof(Color)] = Color;
       }
         
       return Color;
   }

   public MeshVertexAttributesSerializationRecord ToProtobuf()
   {
       return new MeshVertexAttributesSerializationRecord(Color,
           Normal,
           Position,
           Tangent,
           Uv);
   }
}