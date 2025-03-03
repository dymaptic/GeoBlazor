
export async function buildJsCIMGeometricEffectDashes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectDashesGenerated } = await import('./cIMGeometricEffectDashes.gb');
    return await buildJsCIMGeometricEffectDashesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectDashes(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectDashesGenerated } = await import('./cIMGeometricEffectDashes.gb');
    return await buildDotNetCIMGeometricEffectDashesGenerated(jsObject);
}
