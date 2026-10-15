
export async function buildJsLengthDimensionResult(dotNetObject: any): Promise<any> {
    let { buildJsLengthDimensionResultGenerated } = await import('./lengthDimensionResult.gb');
    return await buildJsLengthDimensionResultGenerated(dotNetObject);
}     

export async function buildDotNetLengthDimensionResult(jsObject: any): Promise<any> {
    let { buildDotNetLengthDimensionResultGenerated } = await import('./lengthDimensionResult.gb');
    return await buildDotNetLengthDimensionResultGenerated(jsObject);
}
