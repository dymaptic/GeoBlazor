
export async function buildJsIContentContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIContentContentGenerated } = await import('./iContentContent.gb');
    return await buildJsIContentContentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIContentContent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIContentContentGenerated } = await import('./iContentContent.gb');
    return await buildDotNetIContentContentGenerated(jsObject, layerId, viewId);
}
