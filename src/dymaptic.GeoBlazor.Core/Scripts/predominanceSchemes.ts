export async function buildJsPredominanceSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceSchemesGenerated} = await import('./predominanceSchemes.gb');
    return await buildJsPredominanceSchemesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominanceSchemes(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceSchemesGenerated} = await import('./predominanceSchemes.gb');
    return await buildDotNetPredominanceSchemesGenerated(jsObject);
}
