
export async function buildJsCIMGeometricEffectJog(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectJogGenerated } = await import('./cIMGeometricEffectJog.gb');
    return await buildJsCIMGeometricEffectJogGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectJog(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectJogGenerated } = await import('./cIMGeometricEffectJog.gb');
    return await buildDotNetCIMGeometricEffectJogGenerated(jsObject);
}
