export async function buildJsOffsetParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOffsetParametersGenerated } = await import('./offsetParameters.gb');
    return await buildJsOffsetParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetOffsetParameters(jsObject: any): Promise<any> {
    let { buildDotNetOffsetParametersGenerated } = await import('./offsetParameters.gb');
    return await buildDotNetOffsetParametersGenerated(jsObject);
}
