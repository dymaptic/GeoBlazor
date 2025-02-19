
export async function buildJsFindImagesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFindImagesResultGenerated } = await import('./findImagesResult.gb');
    return await buildJsFindImagesResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFindImagesResult(jsObject: any): Promise<any> {
    let { buildDotNetFindImagesResultGenerated } = await import('./findImagesResult.gb');
    return await buildDotNetFindImagesResultGenerated(jsObject);
}
