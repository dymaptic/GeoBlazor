
export async function buildJsViewing(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewingGenerated } = await import('./viewing.gb');
    return await buildJsViewingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewing(jsObject: any): Promise<any> {
    let { buildDotNetViewingGenerated } = await import('./viewing.gb');
    return await buildDotNetViewingGenerated(jsObject);
}
