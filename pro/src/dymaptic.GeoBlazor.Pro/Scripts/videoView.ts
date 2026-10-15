
export async function buildJsVideoView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoViewGenerated } = await import('./videoView.gb');
    return await buildJsVideoViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVideoViewGenerated } = await import('./videoView.gb');
    return await buildDotNetVideoViewGenerated(jsObject, layerId, viewId);
}
