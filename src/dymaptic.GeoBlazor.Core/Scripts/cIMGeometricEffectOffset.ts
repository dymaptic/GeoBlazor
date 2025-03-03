
export async function buildJsCIMGeometricEffectOffset(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectOffsetGenerated } = await import('./cIMGeometricEffectOffset.gb');
    return await buildJsCIMGeometricEffectOffsetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectOffset(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectOffsetGenerated } = await import('./cIMGeometricEffectOffset.gb');
    return await buildDotNetCIMGeometricEffectOffsetGenerated(jsObject);
}
