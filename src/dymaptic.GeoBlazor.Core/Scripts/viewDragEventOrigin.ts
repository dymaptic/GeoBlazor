
export async function buildJsViewDragEventOrigin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewDragEventOriginGenerated } = await import('./viewDragEventOrigin.gb');
    return await buildJsViewDragEventOriginGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewDragEventOrigin(jsObject: any): Promise<any> {
    let { buildDotNetViewDragEventOriginGenerated } = await import('./viewDragEventOrigin.gb');
    return await buildDotNetViewDragEventOriginGenerated(jsObject);
}
