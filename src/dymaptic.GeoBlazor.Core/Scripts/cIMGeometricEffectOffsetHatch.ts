
export async function buildJsCIMGeometricEffectOffsetHatch(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectOffsetHatchGenerated } = await import('./cIMGeometricEffectOffsetHatch.gb');
    return await buildJsCIMGeometricEffectOffsetHatchGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectOffsetHatch(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectOffsetHatchGenerated } = await import('./cIMGeometricEffectOffsetHatch.gb');
    return await buildDotNetCIMGeometricEffectOffsetHatchGenerated(jsObject);
}
