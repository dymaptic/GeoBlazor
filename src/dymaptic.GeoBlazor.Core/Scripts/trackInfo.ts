
export async function buildJsTrackInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTrackInfoGenerated } = await import('./trackInfo.gb');
    return await buildJsTrackInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTrackInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTrackInfoGenerated } = await import('./trackInfo.gb');
    return await buildDotNetTrackInfoGenerated(jsObject, viewId);
}
