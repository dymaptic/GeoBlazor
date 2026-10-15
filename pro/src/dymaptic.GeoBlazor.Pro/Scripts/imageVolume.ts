
export async function buildJsImageVolume(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageVolumeGenerated } = await import('./imageVolume.gb');
    return await buildJsImageVolumeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageVolume(jsObject: any): Promise<any> {
    let { buildDotNetImageVolumeGenerated } = await import('./imageVolume.gb');
    return await buildDotNetImageVolumeGenerated(jsObject);
}
