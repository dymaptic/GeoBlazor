
export async function buildJsIPortalLayer(dotNetObject: any): Promise<any> {
    let { buildJsIPortalLayerGenerated } = await import('./iPortalLayer.gb');
    return await buildJsIPortalLayerGenerated(dotNetObject);
}     

export async function buildDotNetIPortalLayer(jsObject: any): Promise<any> {
    let { buildDotNetIPortalLayerGenerated } = await import('./iPortalLayer.gb');
    return await buildDotNetIPortalLayerGenerated(jsObject);
}
