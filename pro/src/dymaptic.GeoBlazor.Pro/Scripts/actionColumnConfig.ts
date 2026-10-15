
export async function buildJsActionColumnConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsActionColumnConfigGenerated } = await import('./actionColumnConfig.gb');
    return await buildJsActionColumnConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetActionColumnConfig(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetActionColumnConfigGenerated } = await import('./actionColumnConfig.gb');
    return await buildDotNetActionColumnConfigGenerated(jsObject, layerId, viewId);
}
