
export async function buildJsCIMGeometricEffectCut(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectCutGenerated } = await import('./cIMGeometricEffectCut.gb');
    return await buildJsCIMGeometricEffectCutGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectCut(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectCutGenerated } = await import('./cIMGeometricEffectCut.gb');
    return await buildDotNetCIMGeometricEffectCutGenerated(jsObject);
}
