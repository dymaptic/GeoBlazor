
export async function buildJsFileLink(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFileLinkGenerated } = await import('./fileLink.gb');
    return await buildJsFileLinkGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFileLink(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFileLinkGenerated } = await import('./fileLink.gb');
    return await buildDotNetFileLinkGenerated(jsObject, layerId, viewId);
}
