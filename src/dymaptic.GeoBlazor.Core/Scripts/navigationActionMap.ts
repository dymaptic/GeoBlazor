
export async function buildJsNavigationActionMap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNavigationActionMapGenerated } = await import('./navigationActionMap.gb');
    return await buildJsNavigationActionMapGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNavigationActionMap(jsObject: any): Promise<any> {
    let { buildDotNetNavigationActionMapGenerated } = await import('./navigationActionMap.gb');
    return await buildDotNetNavigationActionMapGenerated(jsObject);
}
