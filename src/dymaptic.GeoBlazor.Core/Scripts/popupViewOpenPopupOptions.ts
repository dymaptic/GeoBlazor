export async function buildJsPopupViewOpenPopupOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupViewOpenPopupOptionsGenerated } = await import('./popupViewOpenPopupOptions.gb');
    return await buildJsPopupViewOpenPopupOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPopupViewOpenPopupOptions(jsObject: any): Promise<any> {
    let { buildDotNetPopupViewOpenPopupOptionsGenerated } = await import('./popupViewOpenPopupOptions.gb');
    return await buildDotNetPopupViewOpenPopupOptionsGenerated(jsObject);
}
