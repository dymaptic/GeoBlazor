
export async function buildJsPolygonSlicerOperatorFindSlicesByAreaOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonSlicerOperatorFindSlicesByAreaOptionsGenerated } = await import('./polygonSlicerOperatorFindSlicesByAreaOptions.gb');
    return await buildJsPolygonSlicerOperatorFindSlicesByAreaOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonSlicerOperatorFindSlicesByAreaOptions(jsObject: any): Promise<any> {
    let { buildDotNetPolygonSlicerOperatorFindSlicesByAreaOptionsGenerated } = await import('./polygonSlicerOperatorFindSlicesByAreaOptions.gb');
    return await buildDotNetPolygonSlicerOperatorFindSlicesByAreaOptionsGenerated(jsObject);
}
