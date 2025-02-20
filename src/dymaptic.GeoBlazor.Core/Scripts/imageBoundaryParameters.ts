// override generated code in this file

export async function buildJsImageBoundaryParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageBoundaryParametersGenerated} = await import('./imageBoundaryParameters.gb');
    return await buildJsImageBoundaryParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageBoundaryParameters(jsObject: any): Promise<any> {
    let {buildDotNetImageBoundaryParametersGenerated} = await import('./imageBoundaryParameters.gb');
    return await buildDotNetImageBoundaryParametersGenerated(jsObject);
}
