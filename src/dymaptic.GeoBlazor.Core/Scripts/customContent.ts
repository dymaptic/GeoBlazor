
export async function buildJsCustomContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCustomContentGenerated } = await import('./customContent.gb');
    return await buildJsCustomContentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCustomContent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCustomContentGenerated } = await import('./customContent.gb');
    return await buildDotNetCustomContentGenerated(jsObject, layerId, viewId);
}
