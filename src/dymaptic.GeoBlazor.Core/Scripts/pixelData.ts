
export async function buildJsPixelData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPixelDataGenerated } = await import('./pixelData.gb');
    return await buildJsPixelDataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPixelData(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPixelDataGenerated } = await import('./pixelData.gb');
    return await buildDotNetPixelDataGenerated(jsObject, layerId, viewId);
}
