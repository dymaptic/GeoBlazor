
export async function buildJsILayerParent(dotNetObject: any): Promise<any> {
    let { buildJsILayerParentGenerated } = await import('./iLayerParent.gb');
    return await buildJsILayerParentGenerated(dotNetObject);
}     

export async function buildDotNetILayerParent(jsObject: any): Promise<any> {
    let { buildDotNetILayerParentGenerated } = await import('./iLayerParent.gb');
    return await buildDotNetILayerParentGenerated(jsObject);
}
