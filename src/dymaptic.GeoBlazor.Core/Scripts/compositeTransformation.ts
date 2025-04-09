
export async function buildJsCompositeTransformation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCompositeTransformationGenerated } = await import('./compositeTransformation.gb');
    return await buildJsCompositeTransformationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCompositeTransformation(jsObject: any): Promise<any> {
    let { buildDotNetCompositeTransformationGenerated } = await import('./compositeTransformation.gb');
    return await buildDotNetCompositeTransformationGenerated(jsObject);
}
