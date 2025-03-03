
export async function buildJsCIMGeometricEffectMove(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectMoveGenerated } = await import('./cIMGeometricEffectMove.gb');
    return await buildJsCIMGeometricEffectMoveGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectMove(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectMoveGenerated } = await import('./cIMGeometricEffectMove.gb');
    return await buildDotNetCIMGeometricEffectMoveGenerated(jsObject);
}
