
export async function buildJsISublayersOwner(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISublayersOwnerGenerated } = await import('./iSublayersOwner.gb');
    return await buildJsISublayersOwnerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISublayersOwner(jsObject: any): Promise<any> {
    let { buildDotNetISublayersOwnerGenerated } = await import('./iSublayersOwner.gb');
    return await buildDotNetISublayersOwnerGenerated(jsObject);
}
