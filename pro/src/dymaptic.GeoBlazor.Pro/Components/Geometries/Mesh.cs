namespace dymaptic.GeoBlazor.Pro.Components.Geometries;

[Experimental("GeoBlazor_Untested", UrlFormat = "https://docs.geoblazor.com/pages/untested.html")]
public partial class Mesh: Geometry
{
   // Add custom code to this file to override generated code

   /// <inheritdoc />
   public override GeometryType Type => GeometryType.Mesh;

   internal override GeometrySerializationRecord ToSerializationRecord()
   {
      throw new NotImplementedException();
   }
}