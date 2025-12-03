
export async function buildJsSlidePopupInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSlidePopupInfoGenerated } = await import('./slidePopupInfo.gb');
    return await buildJsSlidePopupInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSlidePopupInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSlidePopupInfoGenerated } = await import('./slidePopupInfo.gb');
    return await buildDotNetSlidePopupInfoGenerated(jsObject, layerId, viewId);
}
