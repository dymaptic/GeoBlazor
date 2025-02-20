// override generated code in this file

export async function buildJsFindImagesParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFindImagesParametersGenerated} = await import('./findImagesParameters.gb');
    return await buildJsFindImagesParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFindImagesParameters(jsObject: any): Promise<any> {
    let {buildDotNetFindImagesParametersGenerated} = await import('./findImagesParameters.gb');
    return await buildDotNetFindImagesParametersGenerated(jsObject);
}
