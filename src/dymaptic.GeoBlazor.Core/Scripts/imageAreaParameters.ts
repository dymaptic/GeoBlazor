// override generated code in this file

export async function buildJsImageAreaParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageAreaParametersGenerated} = await import('./imageAreaParameters.gb');
    return await buildJsImageAreaParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageAreaParameters(jsObject: any): Promise<any> {
    let {buildDotNetImageAreaParametersGenerated} = await import('./imageAreaParameters.gb');
    return await buildDotNetImageAreaParametersGenerated(jsObject);
}
