
export async function buildJsCIMGeometricEffectExtension(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectExtensionGenerated } = await import('./cIMGeometricEffectExtension.gb');
    return await buildJsCIMGeometricEffectExtensionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectExtension(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectExtensionGenerated } = await import('./cIMGeometricEffectExtension.gb');
    return await buildDotNetCIMGeometricEffectExtensionGenerated(jsObject);
}
