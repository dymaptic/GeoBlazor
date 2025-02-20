export async function buildJsBaseImageMeasureParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseImageMeasureParametersGenerated} = await import('./baseImageMeasureParameters.gb');
    return await buildJsBaseImageMeasureParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseImageMeasureParameters(jsObject: any): Promise<any> {
    let {buildDotNetBaseImageMeasureParametersGenerated} = await import('./baseImageMeasureParameters.gb');
    return await buildDotNetBaseImageMeasureParametersGenerated(jsObject);
}
