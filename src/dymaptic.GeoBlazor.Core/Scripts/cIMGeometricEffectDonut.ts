
export async function buildJsCIMGeometricEffectDonut(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectDonutGenerated } = await import('./cIMGeometricEffectDonut.gb');
    return await buildJsCIMGeometricEffectDonutGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectDonut(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectDonutGenerated } = await import('./cIMGeometricEffectDonut.gb');
    return await buildDotNetCIMGeometricEffectDonutGenerated(jsObject);
}
