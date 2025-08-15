
export async function buildJsIPortalLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIPortalLayerGenerated } = await import('./iPortalLayer.gb');
    return await buildJsIPortalLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIPortalLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIPortalLayerGenerated } = await import('./iPortalLayer.gb');
    return await buildDotNetIPortalLayerGenerated(jsObject, viewId);
}
