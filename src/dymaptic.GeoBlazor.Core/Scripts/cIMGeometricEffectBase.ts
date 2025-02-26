
export async function buildJsCIMGeometricEffectBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectBaseGenerated } = await import('./cIMGeometricEffectBase.gb');
    return await buildJsCIMGeometricEffectBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectBase(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectBaseGenerated } = await import('./cIMGeometricEffectBase.gb');
    return await buildDotNetCIMGeometricEffectBaseGenerated(jsObject);
}
