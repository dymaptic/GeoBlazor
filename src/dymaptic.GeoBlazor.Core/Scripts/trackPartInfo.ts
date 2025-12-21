
export async function buildJsTrackPartInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTrackPartInfoGenerated } = await import('./trackPartInfo.gb');
    return await buildJsTrackPartInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTrackPartInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTrackPartInfoGenerated } = await import('./trackPartInfo.gb');
    return await buildDotNetTrackPartInfoGenerated(jsObject, layerId, viewId);
}
