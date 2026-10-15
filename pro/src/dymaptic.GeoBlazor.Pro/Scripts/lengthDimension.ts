
export async function buildJsLengthDimension(dotNetObject: any): Promise<any> {
    let { buildJsLengthDimensionGenerated } = await import('./lengthDimension.gb');
    return await buildJsLengthDimensionGenerated(dotNetObject);
}     

export async function buildDotNetLengthDimension(jsObject: any): Promise<any> {
    let { buildDotNetLengthDimensionGenerated } = await import('./lengthDimension.gb');
    return await buildDotNetLengthDimensionGenerated(jsObject);
}
