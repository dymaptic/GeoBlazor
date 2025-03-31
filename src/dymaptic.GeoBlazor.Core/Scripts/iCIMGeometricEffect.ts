
export async function buildJsICIMGeometricEffect(dotNetObject: any): Promise<any> {
    let { buildJsICIMGeometricEffectGenerated } = await import('./iCIMGeometricEffect.gb');
    return await buildJsICIMGeometricEffectGenerated(dotNetObject);
}     

export async function buildDotNetICIMGeometricEffect(jsObject: any): Promise<any> {
    let { buildDotNetICIMGeometricEffectGenerated } = await import('./iCIMGeometricEffect.gb');
    return await buildDotNetICIMGeometricEffectGenerated(jsObject);
}
