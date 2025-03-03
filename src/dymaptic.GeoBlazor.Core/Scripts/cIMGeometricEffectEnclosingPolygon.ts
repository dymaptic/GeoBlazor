
export async function buildJsCIMGeometricEffectEnclosingPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectEnclosingPolygonGenerated } = await import('./cIMGeometricEffectEnclosingPolygon.gb');
    return await buildJsCIMGeometricEffectEnclosingPolygonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectEnclosingPolygon(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectEnclosingPolygonGenerated } = await import('./cIMGeometricEffectEnclosingPolygon.gb');
    return await buildDotNetCIMGeometricEffectEnclosingPolygonGenerated(jsObject);
}
