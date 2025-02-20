export async function buildJsViewClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewClickEventGenerated} = await import('./viewClickEvent.gb');
    return await buildJsViewClickEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewClickEvent(jsObject: any): Promise<any> {
    let {buildDotNetViewClickEventGenerated} = await import('./viewClickEvent.gb');
    return await buildDotNetViewClickEventGenerated(jsObject);
}
