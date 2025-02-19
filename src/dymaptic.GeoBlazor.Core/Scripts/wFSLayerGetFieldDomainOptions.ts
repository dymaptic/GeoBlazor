
export async function buildJsWFSLayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerGetFieldDomainOptionsGenerated } = await import('./wFSLayerGetFieldDomainOptions.gb');
    return await buildJsWFSLayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerGetFieldDomainOptionsGenerated } = await import('./wFSLayerGetFieldDomainOptions.gb');
    return await buildDotNetWFSLayerGetFieldDomainOptionsGenerated(jsObject);
}
