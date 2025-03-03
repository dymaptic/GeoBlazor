
export async function buildJsCIMGeometricEffectScale(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectScaleGenerated } = await import('./cIMGeometricEffectScale.gb');
    return await buildJsCIMGeometricEffectScaleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectScale(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectScaleGenerated } = await import('./cIMGeometricEffectScale.gb');
    return await buildDotNetCIMGeometricEffectScaleGenerated(jsObject);
}
