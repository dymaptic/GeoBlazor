
export async function buildJsISublayersOwner(dotNetObject: any): Promise<any> {
    let { buildJsISublayersOwnerGenerated } = await import('./iSublayersOwner.gb');
    return buildJsISublayersOwnerGenerated(dotNetObject);
}     

export async function buildDotNetISublayersOwner(jsObject: any): Promise<any> {
    let { buildDotNetISublayersOwnerGenerated } = await import('./iSublayersOwner.gb');
    return await buildDotNetISublayersOwnerGenerated(jsObject);
}
