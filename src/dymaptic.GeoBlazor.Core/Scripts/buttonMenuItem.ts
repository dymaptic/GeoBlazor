
export async function buildJsButtonMenuItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsButtonMenuItemGenerated } = await import('./buttonMenuItem.gb');
    return await buildJsButtonMenuItemGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetButtonMenuItem(jsObject: any): Promise<any> {
    let { buildDotNetButtonMenuItemGenerated } = await import('./buttonMenuItem.gb');
    return await buildDotNetButtonMenuItemGenerated(jsObject);
}
