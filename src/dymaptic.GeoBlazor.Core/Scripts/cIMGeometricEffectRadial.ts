
export async function buildJsCIMGeometricEffectRadial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectRadialGenerated } = await import('./cIMGeometricEffectRadial.gb');
    return await buildJsCIMGeometricEffectRadialGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectRadial(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectRadialGenerated } = await import('./cIMGeometricEffectRadial.gb');
    return await buildDotNetCIMGeometricEffectRadialGenerated(jsObject);
}
