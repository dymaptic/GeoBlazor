// override generated code in this file

export async function buildJsImageSampleParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageSampleParametersGenerated} = await import('./imageSampleParameters.gb');
    return await buildJsImageSampleParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageSampleParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageSampleParametersGenerated} = await import('./imageSampleParameters.gb');
    return await buildDotNetImageSampleParametersGenerated(jsObject, layerId, viewId);
}
