
export async function buildJsSiteLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSiteLayerInfoGenerated } = await import('./siteLayerInfo.gb');
    return await buildJsSiteLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSiteLayerInfo(jsObject: any): Promise<any> {
    let { buildDotNetSiteLayerInfoGenerated } = await import('./siteLayerInfo.gb');
    return await buildDotNetSiteLayerInfoGenerated(jsObject);
}
