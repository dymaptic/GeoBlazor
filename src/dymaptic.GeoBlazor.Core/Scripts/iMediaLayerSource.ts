
export async function buildJsIMediaLayerSource(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIMediaLayerSourceGenerated } = await import('./iMediaLayerSource.gb');
    return await buildJsIMediaLayerSourceGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIMediaLayerSource(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIMediaLayerSourceGenerated } = await import('./iMediaLayerSource.gb');
    return await buildDotNetIMediaLayerSourceGenerated(jsObject, viewId);
}
