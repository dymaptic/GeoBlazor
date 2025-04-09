
export async function buildJsCompositeTransformationGeoTransforms(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCompositeTransformationGeoTransformsGenerated } = await import('./compositeTransformationGeoTransforms.gb');
    return await buildJsCompositeTransformationGeoTransformsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCompositeTransformationGeoTransforms(jsObject: any): Promise<any> {
    let { buildDotNetCompositeTransformationGeoTransformsGenerated } = await import('./compositeTransformationGeoTransforms.gb');
    return await buildDotNetCompositeTransformationGeoTransformsGenerated(jsObject);
}
