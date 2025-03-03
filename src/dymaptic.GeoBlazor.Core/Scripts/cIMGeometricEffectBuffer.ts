
export async function buildJsCIMGeometricEffectBuffer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectBufferGenerated } = await import('./cIMGeometricEffectBuffer.gb');
    return await buildJsCIMGeometricEffectBufferGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectBuffer(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectBufferGenerated } = await import('./cIMGeometricEffectBuffer.gb');
    return await buildDotNetCIMGeometricEffectBufferGenerated(jsObject);
}
