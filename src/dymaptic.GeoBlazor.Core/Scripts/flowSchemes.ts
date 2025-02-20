export async function buildJsFlowSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFlowSchemesGenerated} = await import('./flowSchemes.gb');
    return await buildJsFlowSchemesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFlowSchemes(jsObject: any): Promise<any> {
    let {buildDotNetFlowSchemesGenerated} = await import('./flowSchemes.gb');
    return await buildDotNetFlowSchemesGenerated(jsObject);
}
