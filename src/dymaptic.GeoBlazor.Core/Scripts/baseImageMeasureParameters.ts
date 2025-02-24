
export async function buildJsBaseImageMeasureParameters(dotNetObject: any): Promise<any> {
    let { buildJsBaseImageMeasureParametersGenerated } = await import('./baseImageMeasureParameters.gb');
    return buildJsBaseImageMeasureParametersGenerated(dotNetObject);
}     

export async function buildDotNetBaseImageMeasureParameters(jsObject: any): Promise<any> {
    let { buildDotNetBaseImageMeasureParametersGenerated } = await import('./baseImageMeasureParameters.gb');
    return await buildDotNetBaseImageMeasureParametersGenerated(jsObject);
}
