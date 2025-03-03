
export async function buildJsCIMGeometricEffectOffsetTangent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectOffsetTangentGenerated } = await import('./cIMGeometricEffectOffsetTangent.gb');
    return await buildJsCIMGeometricEffectOffsetTangentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectOffsetTangent(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectOffsetTangentGenerated } = await import('./cIMGeometricEffectOffsetTangent.gb');
    return await buildDotNetCIMGeometricEffectOffsetTangentGenerated(jsObject);
}
