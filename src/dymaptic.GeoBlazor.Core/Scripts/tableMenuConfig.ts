
export async function buildJsTableMenuConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableMenuConfigGenerated } = await import('./tableMenuConfig.gb');
    return await buildJsTableMenuConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableMenuConfig(jsObject: any): Promise<any> {
    let { buildDotNetTableMenuConfigGenerated } = await import('./tableMenuConfig.gb');
    return await buildDotNetTableMenuConfigGenerated(jsObject);
}
