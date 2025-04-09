
export async function buildJsPolygonSlicerOperatorRecursiveSliceEqualAreaOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonSlicerOperatorRecursiveSliceEqualAreaOptionsGenerated } = await import('./polygonSlicerOperatorRecursiveSliceEqualAreaOptions.gb');
    return await buildJsPolygonSlicerOperatorRecursiveSliceEqualAreaOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonSlicerOperatorRecursiveSliceEqualAreaOptions(jsObject: any): Promise<any> {
    let { buildDotNetPolygonSlicerOperatorRecursiveSliceEqualAreaOptionsGenerated } = await import('./polygonSlicerOperatorRecursiveSliceEqualAreaOptions.gb');
    return await buildDotNetPolygonSlicerOperatorRecursiveSliceEqualAreaOptionsGenerated(jsObject);
}
