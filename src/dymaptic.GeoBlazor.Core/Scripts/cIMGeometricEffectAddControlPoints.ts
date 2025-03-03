
export async function buildJsCIMGeometricEffectAddControlPoints(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectAddControlPointsGenerated } = await import('./cIMGeometricEffectAddControlPoints.gb');
    return await buildJsCIMGeometricEffectAddControlPointsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectAddControlPoints(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectAddControlPointsGenerated } = await import('./cIMGeometricEffectAddControlPoints.gb');
    return await buildDotNetCIMGeometricEffectAddControlPointsGenerated(jsObject);
}
