export async function buildJsMeasureLengthFromImageResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMeasureLengthFromImageResultGenerated} = await import('./measureLengthFromImageResult.gb');
    return await buildJsMeasureLengthFromImageResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMeasureLengthFromImageResult(jsObject: any): Promise<any> {
    let {buildDotNetMeasureLengthFromImageResultGenerated} = await import('./measureLengthFromImageResult.gb');
    return await buildDotNetMeasureLengthFromImageResultGenerated(jsObject);
}
