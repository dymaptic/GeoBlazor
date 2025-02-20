export async function buildJsPopupOpenOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupOpenOptionsGenerated} = await import('./popupOpenOptions.gb');
    return await buildJsPopupOpenOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupOpenOptions(jsObject: any): Promise<any> {
    let {buildDotNetPopupOpenOptionsGenerated} = await import('./popupOpenOptions.gb');
    return await buildDotNetPopupOpenOptionsGenerated(jsObject);
}
