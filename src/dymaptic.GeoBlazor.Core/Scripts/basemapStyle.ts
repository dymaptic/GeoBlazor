
export async function buildJsBasemapStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildJsBasemapStyleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBasemapStyle(jsObject: any): Promise<any> {
    let { buildDotNetBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildDotNetBasemapStyleGenerated(jsObject);
}
