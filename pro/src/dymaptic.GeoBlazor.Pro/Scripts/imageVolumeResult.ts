
export async function buildJsImageVolumeResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageVolumeResultGenerated } = await import('./imageVolumeResult.gb');
    return await buildJsImageVolumeResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageVolumeResult(jsObject: any): Promise<any> {
    let { buildDotNetImageVolumeResultGenerated } = await import('./imageVolumeResult.gb');
    return await buildDotNetImageVolumeResultGenerated(jsObject);
}
