
export async function buildJsCIMGeometricEffectRotate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectRotateGenerated } = await import('./cIMGeometricEffectRotate.gb');
    return await buildJsCIMGeometricEffectRotateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectRotate(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectRotateGenerated } = await import('./cIMGeometricEffectRotate.gb');
    return await buildDotNetCIMGeometricEffectRotateGenerated(jsObject);
}
