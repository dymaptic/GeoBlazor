export async function buildJsLengthDimension(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLengthDimensionGenerated} = await import('./lengthDimension.gb');
    return await buildJsLengthDimensionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLengthDimension(jsObject: any): Promise<any> {
    let {buildDotNetLengthDimensionGenerated} = await import('./lengthDimension.gb');
    return await buildDotNetLengthDimensionGenerated(jsObject);
}
