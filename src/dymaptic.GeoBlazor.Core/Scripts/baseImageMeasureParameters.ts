
export async function buildJsBaseImageMeasureParameters(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBaseImageMeasureParametersGenerated } = await import('./baseImageMeasureParameters.gb');
    return await buildJsBaseImageMeasureParametersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBaseImageMeasureParameters(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBaseImageMeasureParametersGenerated } = await import('./baseImageMeasureParameters.gb');
    return await buildDotNetBaseImageMeasureParametersGenerated(jsObject, viewId);
}
