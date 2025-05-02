
export async function buildJsServiceEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceEditsGenerated } = await import('./serviceEdits.gb');
    return await buildJsServiceEditsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceEdits(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetServiceEditsGenerated } = await import('./serviceEdits.gb');
    return await buildDotNetServiceEditsGenerated(jsObject, layerId, viewId);
}
