
export async function buildJsWebDocument2DUpdateFromOptionsThumbnailSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebDocument2DUpdateFromOptionsThumbnailSizeGenerated } = await import('./webDocument2DUpdateFromOptionsThumbnailSize.gb');
    return await buildJsWebDocument2DUpdateFromOptionsThumbnailSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebDocument2DUpdateFromOptionsThumbnailSize(jsObject: any): Promise<any> {
    let { buildDotNetWebDocument2DUpdateFromOptionsThumbnailSizeGenerated } = await import('./webDocument2DUpdateFromOptionsThumbnailSize.gb');
    return await buildDotNetWebDocument2DUpdateFromOptionsThumbnailSizeGenerated(jsObject);
}
