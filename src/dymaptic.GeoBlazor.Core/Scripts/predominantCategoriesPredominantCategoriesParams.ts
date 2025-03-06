
export async function buildJsPredominantCategoriesPredominantCategoriesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominantCategoriesPredominantCategoriesParamsGenerated } = await import('./predominantCategoriesPredominantCategoriesParams.gb');
    return await buildJsPredominantCategoriesPredominantCategoriesParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominantCategoriesPredominantCategoriesParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPredominantCategoriesPredominantCategoriesParamsGenerated } = await import('./predominantCategoriesPredominantCategoriesParams.gb');
    return await buildDotNetPredominantCategoriesPredominantCategoriesParamsGenerated(jsObject, layerId, viewId);
}
