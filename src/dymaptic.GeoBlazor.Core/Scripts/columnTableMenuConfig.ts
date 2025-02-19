
export async function buildJsColumnTableMenuConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColumnTableMenuConfigGenerated } = await import('./columnTableMenuConfig.gb');
    return await buildJsColumnTableMenuConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColumnTableMenuConfig(jsObject: any): Promise<any> {
    let { buildDotNetColumnTableMenuConfigGenerated } = await import('./columnTableMenuConfig.gb');
    return await buildDotNetColumnTableMenuConfigGenerated(jsObject);
}
