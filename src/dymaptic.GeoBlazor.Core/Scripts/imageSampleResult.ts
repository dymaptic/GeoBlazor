export async function buildJsImageSampleResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageSampleResultGenerated} = await import('./imageSampleResult.gb');
    return await buildJsImageSampleResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageSampleResult(jsObject: any): Promise<any> {
    let {buildDotNetImageSampleResultGenerated} = await import('./imageSampleResult.gb');
    return await buildDotNetImageSampleResultGenerated(jsObject);
}
