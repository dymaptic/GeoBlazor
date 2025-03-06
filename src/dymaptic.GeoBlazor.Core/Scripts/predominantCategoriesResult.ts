
export async function buildJsPredominantCategoriesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominantCategoriesResultGenerated } = await import('./predominantCategoriesResult.gb');
    return await buildJsPredominantCategoriesResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominantCategoriesResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPredominantCategoriesResultGenerated } = await import('./predominantCategoriesResult.gb');
    return await buildDotNetPredominantCategoriesResultGenerated(jsObject, layerId, viewId);
}
