
export async function buildJsIMediaLayerSource(dotNetObject: any): Promise<any> {
    let { buildJsIMediaLayerSourceGenerated } = await import('./iMediaLayerSource.gb');
    return await buildJsIMediaLayerSourceGenerated(dotNetObject);
}     

export async function buildDotNetIMediaLayerSource(jsObject: any): Promise<any> {
    let { buildDotNetIMediaLayerSourceGenerated } = await import('./iMediaLayerSource.gb');
    return await buildDotNetIMediaLayerSourceGenerated(jsObject);
}
