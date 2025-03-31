
export async function buildJsPredominantCategoriesResultPredominantCategoryInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominantCategoriesResultPredominantCategoryInfosGenerated } = await import('./predominantCategoriesResultPredominantCategoryInfos.gb');
    return await buildJsPredominantCategoriesResultPredominantCategoryInfosGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominantCategoriesResultPredominantCategoryInfos(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPredominantCategoriesResultPredominantCategoryInfosGenerated } = await import('./predominantCategoriesResultPredominantCategoryInfos.gb');
    return await buildDotNetPredominantCategoriesResultPredominantCategoryInfosGenerated(jsObject, layerId, viewId);
}
