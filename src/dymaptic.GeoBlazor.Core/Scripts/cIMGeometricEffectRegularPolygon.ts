
export async function buildJsCIMGeometricEffectRegularPolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectRegularPolygonGenerated } = await import('./cIMGeometricEffectRegularPolygon.gb');
    return await buildJsCIMGeometricEffectRegularPolygonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectRegularPolygon(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectRegularPolygonGenerated } = await import('./cIMGeometricEffectRegularPolygon.gb');
    return await buildDotNetCIMGeometricEffectRegularPolygonGenerated(jsObject);
}
