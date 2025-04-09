
export async function buildJsCompositeTransformationGeoTransforms1(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCompositeTransformationGeoTransforms1Generated } = await import('./compositeTransformationGeoTransforms1.gb');
    return await buildJsCompositeTransformationGeoTransforms1Generated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCompositeTransformationGeoTransforms1(jsObject: any): Promise<any> {
    let { buildDotNetCompositeTransformationGeoTransforms1Generated } = await import('./compositeTransformationGeoTransforms1.gb');
    return await buildDotNetCompositeTransformationGeoTransforms1Generated(jsObject);
}
