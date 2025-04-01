
export async function buildJsConfigWorkersLoaderConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigWorkersLoaderConfigGenerated } = await import('./configWorkersLoaderConfig.gb');
    return await buildJsConfigWorkersLoaderConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfigWorkersLoaderConfig(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConfigWorkersLoaderConfigGenerated } = await import('./configWorkersLoaderConfig.gb');
    return await buildDotNetConfigWorkersLoaderConfigGenerated(jsObject, layerId, viewId);
}
