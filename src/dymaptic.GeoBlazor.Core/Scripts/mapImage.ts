
export async function buildJsMapImage(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapImageGenerated } = await import('./mapImage.gb');
    return await buildJsMapImageGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapImage(jsObject: any): Promise<any> {
    let { buildDotNetMapImageGenerated } = await import('./mapImage.gb');
    return await buildDotNetMapImageGenerated(jsObject);
}
