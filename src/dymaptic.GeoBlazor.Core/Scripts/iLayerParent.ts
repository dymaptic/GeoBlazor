
export async function buildJsILayerParent(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsILayerParentGenerated } = await import('./iLayerParent.gb');
    return await buildJsILayerParentGenerated(dotNetObject, viewId);
}     

export async function buildDotNetILayerParent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetILayerParentGenerated } = await import('./iLayerParent.gb');
    return await buildDotNetILayerParentGenerated(jsObject, viewId);
}
