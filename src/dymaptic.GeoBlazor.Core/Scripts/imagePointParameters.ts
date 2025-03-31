// override generated code in this file

export async function buildJsImagePointParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImagePointParametersGenerated} = await import('./imagePointParameters.gb');
    return await buildJsImagePointParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImagePointParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImagePointParametersGenerated} = await import('./imagePointParameters.gb');
    return await buildDotNetImagePointParametersGenerated(jsObject, layerId, viewId);
}
