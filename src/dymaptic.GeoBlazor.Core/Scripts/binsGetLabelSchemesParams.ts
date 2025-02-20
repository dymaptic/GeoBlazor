export async function buildJsBinsGetLabelSchemesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBinsGetLabelSchemesParamsGenerated} = await import('./binsGetLabelSchemesParams.gb');
    return await buildJsBinsGetLabelSchemesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBinsGetLabelSchemesParams(jsObject: any): Promise<any> {
    let {buildDotNetBinsGetLabelSchemesParamsGenerated} = await import('./binsGetLabelSchemesParams.gb');
    return await buildDotNetBinsGetLabelSchemesParamsGenerated(jsObject);
}
