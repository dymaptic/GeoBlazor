
export async function buildJsPopupDockOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildJsPopupDockOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPopupDockOptions(jsObject: any): Promise<any> {
    let { buildDotNetPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildDotNetPopupDockOptionsGenerated(jsObject);
}
