
export async function buildJsCIMGeometricEffectLocalizerFeather(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectLocalizerFeatherGenerated } = await import('./cIMGeometricEffectLocalizerFeather.gb');
    return await buildJsCIMGeometricEffectLocalizerFeatherGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectLocalizerFeather(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectLocalizerFeatherGenerated } = await import('./cIMGeometricEffectLocalizerFeather.gb');
    return await buildDotNetCIMGeometricEffectLocalizerFeatherGenerated(jsObject);
}
