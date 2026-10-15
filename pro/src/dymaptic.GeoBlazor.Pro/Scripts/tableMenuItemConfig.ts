// override generated code in this file

export async function buildJsTableMenuItemConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableMenuItemConfigGenerated } = await import('./tableMenuItemConfig.gb');
    return await buildJsTableMenuItemConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableMenuItemConfig(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableMenuItemConfigGenerated } = await import('./tableMenuItemConfig.gb');
    return await buildDotNetTableMenuItemConfigGenerated(jsObject, layerId, viewId);
}

