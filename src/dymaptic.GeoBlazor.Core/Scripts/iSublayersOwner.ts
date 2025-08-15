
export async function buildJsISublayersOwner(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsISublayersOwnerGenerated } = await import('./iSublayersOwner.gb');
    return await buildJsISublayersOwnerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetISublayersOwner(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetISublayersOwnerGenerated } = await import('./iSublayersOwner.gb');
    return await buildDotNetISublayersOwnerGenerated(jsObject, viewId);
}
