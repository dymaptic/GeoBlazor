
export async function buildJsCategory(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCategoryGenerated } = await import('./category.gb');
    return await buildJsCategoryGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCategory(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCategoryGenerated } = await import('./category.gb');
    return await buildDotNetCategoryGenerated(jsObject, layerId, viewId);
}
