
export async function buildJsNavigation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNavigationGenerated } = await import('./navigation.gb');
    return await buildJsNavigationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNavigation(jsObject: any): Promise<any> {
    let { buildDotNetNavigationGenerated } = await import('./navigation.gb');
    return await buildDotNetNavigationGenerated(jsObject);
}
