
export async function buildJsCIMGeometricEffectReverse(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectReverseGenerated } = await import('./cIMGeometricEffectReverse.gb');
    return await buildJsCIMGeometricEffectReverseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectReverse(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectReverseGenerated } = await import('./cIMGeometricEffectReverse.gb');
    return await buildDotNetCIMGeometricEffectReverseGenerated(jsObject);
}
