using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Model;

public class Projection : LogicComponent
{
    public Projection(IJSRuntime jsRuntime, IConfiguration configuration) : base(jsRuntime, configuration)
    {
    }

    protected override string ComponentName => "projection";

    public async Task<Geometry[]?> Project(Geometry[] geometries, SpatialReference spatialReference,
        GeographicTransformation? geographicTransformation = null)
    {
        return await InvokeAsync<Geometry[]?>("project", geometries, spatialReference, 
            geographicTransformation);
    }
    
    
}