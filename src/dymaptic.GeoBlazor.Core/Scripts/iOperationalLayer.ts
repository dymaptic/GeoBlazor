
export async function buildJsIOperationalLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIOperationalLayerGenerated } = await import('./iOperationalLayer.gb');
    return await buildJsIOperationalLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIOperationalLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIOperationalLayerGenerated } = await import('./iOperationalLayer.gb');
    return await buildDotNetIOperationalLayerGenerated(jsObject, viewId);
}
