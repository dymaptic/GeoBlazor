
export async function buildJsLengthDimensionResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLengthDimensionResultGenerated } = await import('./lengthDimensionResult.gb');
    return await buildJsLengthDimensionResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLengthDimensionResult(jsObject: any): Promise<any> {
    let { buildDotNetLengthDimensionResultGenerated } = await import('./lengthDimensionResult.gb');
    return await buildDotNetLengthDimensionResultGenerated(jsObject);
}
