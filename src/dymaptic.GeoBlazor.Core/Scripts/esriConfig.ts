
export async function buildJsEsriConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEsriConfigGenerated } = await import('./esriConfig.gb');
    return await buildJsEsriConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEsriConfig(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEsriConfigGenerated } = await import('./esriConfig.gb');
    return await buildDotNetEsriConfigGenerated(jsObject, layerId, viewId);
}
