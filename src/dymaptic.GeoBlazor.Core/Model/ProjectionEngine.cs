namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A client-side projection engine for converting geometries from one SpatialReference to another. When projecting
///     geometries the starting spatial reference must be specified on the input geometry. You can specify a specific
///     geographic (datum) transformation for the project operation, or accept the default transformation if one is needed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-projection.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class ProjectionEngine : LogicComponent
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="authenticationManager">
    ///     Injected Identity Manager reference
    /// </param>
    public ProjectionEngine(AuthenticationManager authenticationManager) : 
        base(authenticationManager)
    {
    }

    /// <inheritdoc />
    protected override string ComponentName => nameof(ProjectionEngine);

    /// <summary>
    ///     Projects an array of geometries to the specified output spatial reference.
    /// </summary>
    /// <param name="geometries">
    ///     The input geometries to project
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference to which you are converting the geometries' coordinates.
    /// </param>
    /// <returns>
    ///     A collection of projected geometries.
    /// </returns>
    public async Task<Geometry[]?> Project(Geometry[] geometries, SpatialReference spatialReference)
    {
        return await InvokeAsync<Geometry[]?>("project", geometries, spatialReference, null);
    }

    /// <summary>
    ///     Projects an array of geometries to the specified output spatial reference.
    /// </summary>
    /// <param name="geometries">
    ///     The input geometries to project
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference to which you are converting the geometries' coordinates.
    /// </param>
    /// <param name="geographicTransformation">
    ///     The optional geographic transformation used to transform the geometries. Specify this parameter to project a
    ///     geometry when the default transformation is not appropriate for your requirements.
    /// </param>
    /// <returns>
    ///     A collection of projected geometries.
    /// </returns>
    public async Task<Geometry[]?> Project(Geometry[] geometries, SpatialReference spatialReference,
        GeographicTransformation? geographicTransformation)
    {
        return await InvokeAsync<Geometry[]?>("project", geometries, spatialReference,
            geographicTransformation);
    }

    /// <summary>
    ///     Projects a geometry to the specified output spatial reference.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry to project
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference to which you are converting the geometries' coordinates.
    /// </param>
    /// <returns>
    ///     A projected geometry.
    /// </returns>
    public async Task<Geometry?> Project(Geometry geometry, SpatialReference spatialReference)
    {
        return await InvokeAsync<Geometry?>("project", geometry, spatialReference, null);
    }

    /// <summary>
    ///     Projects a geometry to the specified output spatial reference.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry to project
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference to which you are converting the geometries' coordinates.
    /// </param>
    /// <param name="geographicTransformation">
    ///     The optional geographic transformation used to transform the geometries. Specify this parameter to project a
    ///     geometry when the default transformation is not appropriate for your requirements.
    /// </param>
    /// <returns>
    ///     A projected geometry.
    /// </returns>
    public async Task<Geometry?> Project(Geometry geometry, SpatialReference spatialReference,
        GeographicTransformation? geographicTransformation)
    {
        return await InvokeAsync<Geometry?>("project", geometry, spatialReference,
            geographicTransformation);
    }

    /// <summary>
    ///     Returns the default geographic transformation used to convert the geometry from the input spatial reference to the
    ///     output spatial reference. The default transformation is used when projecting geometries where the datum
    ///     transformation is required but not specified in the geographicTransformation parameter.
    /// </summary>
    /// <param name="inSpatialReference">
    ///     The input spatial reference from which to project geometries. This is the spatial reference of the input
    ///     geometries.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference to which you are converting the geometries.
    /// </param>
    /// <param name="extent">
    ///     The optional spatial reference to which you are converting the geometries.
    /// </param>
    /// <returns>
    ///     A geographic transformation.
    /// </returns>
    public async Task<GeographicTransformation?> GetTransformation(SpatialReference inSpatialReference,
        SpatialReference outSpatialReference, Extent extent)
    {
        return await InvokeAsync<GeographicTransformation?>("getTransformation", inSpatialReference,
            outSpatialReference, extent);
    }

    /// <summary>
    ///     Returns a list of all geographic transformations suitable to convert geometries from the input spatial reference to
    ///     the specified output spatial reference. The list is ordered in descending order by suitability, with the most
    ///     suitable being first in the list.
    /// </summary>
    /// <param name="inSpatialReference">
    ///     The spatial reference that the geometries are currently using.
    /// </param>
    /// <param name="outSpatialReference">
    ///     The spatial reference to which you are converting the geometries.
    /// </param>
    /// <param name="extent">
    ///     An optional extent used to determine the suitability of the returned transformations. The extent will be
    ///     re-projected to the input spatial reference if necessary.
    /// </param>
    /// <returns>
    ///     A collection of geographic transformation.
    /// </returns>
    public async Task<GeographicTransformation[]?> GetTransformations(SpatialReference inSpatialReference,
        SpatialReference outSpatialReference, Extent extent)
    {
        return await InvokeAsync<GeographicTransformation[]?>("getTransformations",
            inSpatialReference, outSpatialReference, extent);
    }
}