
export async function buildJsQueryCompositeTransformation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsQueryCompositeTransformationGenerated } = await import('./queryCompositeTransformation.gb');
    return await buildJsQueryCompositeTransformationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetQueryCompositeTransformation(jsObject: any): Promise<any> {
    let { buildDotNetQueryCompositeTransformationGenerated } = await import('./queryCompositeTransformation.gb');
    return await buildDotNetQueryCompositeTransformationGenerated(jsObject);
}
