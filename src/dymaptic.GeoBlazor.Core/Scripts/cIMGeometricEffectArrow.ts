
export async function buildJsCIMGeometricEffectArrow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectArrowGenerated } = await import('./cIMGeometricEffectArrow.gb');
    return await buildJsCIMGeometricEffectArrowGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectArrow(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectArrowGenerated } = await import('./cIMGeometricEffectArrow.gb');
    return await buildDotNetCIMGeometricEffectArrowGenerated(jsObject);
}
