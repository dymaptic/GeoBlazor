export async function buildJsIImageryRenderer(dnRenderer: any, layerId: string | null, viewId: string | null) {
    let { buildJsImageryRenderer } = await import('./imageryRenderer');
    return await buildJsImageryRenderer(dnRenderer, layerId, viewId);
}
export async function buildDotNetIImageryRenderer(jsObject: any): Promise<any> {
    let { buildDotNetImageryRenderer } = await import('./imageryRenderer');
    return await buildDotNetImageryRenderer(jsObject);
}
