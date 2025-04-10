
export async function buildJsPresentation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPresentationGenerated } = await import('./presentation.gb');
    return await buildJsPresentationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPresentation(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPresentationGenerated } = await import('./presentation.gb');
    return await buildDotNetPresentationGenerated(jsObject, layerId, viewId);
}
