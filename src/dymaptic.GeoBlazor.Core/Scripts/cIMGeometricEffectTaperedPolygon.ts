
export async function buildJsCIMGeometricEffectTaperedPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectTaperedPolygonGenerated } = await import('./cIMGeometricEffectTaperedPolygon.gb');
    return await buildJsCIMGeometricEffectTaperedPolygonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectTaperedPolygon(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectTaperedPolygonGenerated } = await import('./cIMGeometricEffectTaperedPolygon.gb');
    return await buildDotNetCIMGeometricEffectTaperedPolygonGenerated(jsObject);
}
