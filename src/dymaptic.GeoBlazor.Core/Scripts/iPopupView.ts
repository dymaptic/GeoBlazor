
export async function buildJsIPopupView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIPopupViewGenerated } = await import('./iPopupView.gb');
    return await buildJsIPopupViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIPopupView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIPopupViewGenerated } = await import('./iPopupView.gb');
    return await buildDotNetIPopupViewGenerated(jsObject, layerId, viewId);
}
