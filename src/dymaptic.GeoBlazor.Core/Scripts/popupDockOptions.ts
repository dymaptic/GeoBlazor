
export async function buildJsPopupDockOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildJsPopupDockOptionsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPopupDockOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildDotNetPopupDockOptionsGenerated(jsObject, viewId);
}
