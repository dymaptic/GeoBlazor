// override generated code in this file

export async function buildJsMapToImageParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMapToImageParametersGenerated} = await import('./mapToImageParameters.gb');
    return await buildJsMapToImageParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMapToImageParameters(jsObject: any): Promise<any> {
    let {buildDotNetMapToImageParametersGenerated} = await import('./mapToImageParameters.gb');
    return await buildDotNetMapToImageParametersGenerated(jsObject);
}
