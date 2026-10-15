
export async function buildJsRelatedInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelatedInfoGenerated } = await import('./relatedInfo.gb');
    return await buildJsRelatedInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelatedInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRelatedInfoGenerated } = await import('./relatedInfo.gb');
    return await buildDotNetRelatedInfoGenerated(jsObject, viewId);
}
