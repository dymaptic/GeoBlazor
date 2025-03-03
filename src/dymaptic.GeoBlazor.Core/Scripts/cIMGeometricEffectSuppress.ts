
export async function buildJsCIMGeometricEffectSuppress(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectSuppressGenerated } = await import('./cIMGeometricEffectSuppress.gb');
    return await buildJsCIMGeometricEffectSuppressGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectSuppress(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectSuppressGenerated } = await import('./cIMGeometricEffectSuppress.gb');
    return await buildDotNetCIMGeometricEffectSuppressGenerated(jsObject);
}
