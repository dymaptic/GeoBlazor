
export async function buildJsICIMGeometricEffectType(dotNetObject: any): Promise<any> {
    let { buildJsICIMGeometricEffectTypeGenerated } = await import('./iCIMGeometricEffectType.gb');
    return await buildJsICIMGeometricEffectTypeGenerated(dotNetObject);
}     

export async function buildDotNetICIMGeometricEffectType(jsObject: any): Promise<any> {
    let { buildDotNetICIMGeometricEffectTypeGenerated } = await import('./iCIMGeometricEffectType.gb');
    return await buildDotNetICIMGeometricEffectTypeGenerated(jsObject);
}
