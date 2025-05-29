
export async function buildJsConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigGenerated } = await import('./config.gb');
    return await buildJsConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfig(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConfigGenerated } = await import('./config.gb');
    return await buildDotNetConfigGenerated(jsObject, layerId, viewId);
}
