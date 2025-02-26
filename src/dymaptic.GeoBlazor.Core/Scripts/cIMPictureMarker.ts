
export async function buildJsCIMPictureMarker(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPictureMarkerGenerated } = await import('./cIMPictureMarker.gb');
    return await buildJsCIMPictureMarkerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMPictureMarker(jsObject: any): Promise<any> {
    let { buildDotNetCIMPictureMarkerGenerated } = await import('./cIMPictureMarker.gb');
    return await buildDotNetCIMPictureMarkerGenerated(jsObject);
}
