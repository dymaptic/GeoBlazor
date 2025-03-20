
export async function buildJsPopupDockOptions(dotNetObject: any): Promise<any> {
    let { buildJsPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildJsPopupDockOptionsGenerated(dotNetObject);
}     

export async function buildDotNetPopupDockOptions(jsObject: any): Promise<any> {
    let { buildDotNetPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildDotNetPopupDockOptionsGenerated(jsObject);
}
