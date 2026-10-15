// override generated code in this file

export async function buildJsImageSample(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageSampleGenerated} = await import('./imageSample.gb');
    return await buildJsImageSampleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageSample(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageSampleGenerated} = await import('./imageSample.gb');
    return await buildDotNetImageSampleGenerated(jsObject, layerId, viewId);
}
