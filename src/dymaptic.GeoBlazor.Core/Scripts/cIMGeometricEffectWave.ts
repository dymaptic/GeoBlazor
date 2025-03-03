
export async function buildJsCIMGeometricEffectWave(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectWaveGenerated } = await import('./cIMGeometricEffectWave.gb');
    return await buildJsCIMGeometricEffectWaveGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectWave(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectWaveGenerated } = await import('./cIMGeometricEffectWave.gb');
    return await buildDotNetCIMGeometricEffectWaveGenerated(jsObject);
}
