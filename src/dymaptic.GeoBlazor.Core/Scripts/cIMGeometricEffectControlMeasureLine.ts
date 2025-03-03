
export async function buildJsCIMGeometricEffectControlMeasureLine(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMGeometricEffectControlMeasureLineGenerated } = await import('./cIMGeometricEffectControlMeasureLine.gb');
    return await buildJsCIMGeometricEffectControlMeasureLineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMGeometricEffectControlMeasureLine(jsObject: any): Promise<any> {
    let { buildDotNetCIMGeometricEffectControlMeasureLineGenerated } = await import('./cIMGeometricEffectControlMeasureLine.gb');
    return await buildDotNetCIMGeometricEffectControlMeasureLineGenerated(jsObject);
}
