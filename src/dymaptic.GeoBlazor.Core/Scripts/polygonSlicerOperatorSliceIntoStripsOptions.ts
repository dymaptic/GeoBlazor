
export async function buildJsPolygonSlicerOperatorSliceIntoStripsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonSlicerOperatorSliceIntoStripsOptionsGenerated } = await import('./polygonSlicerOperatorSliceIntoStripsOptions.gb');
    return await buildJsPolygonSlicerOperatorSliceIntoStripsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonSlicerOperatorSliceIntoStripsOptions(jsObject: any): Promise<any> {
    let { buildDotNetPolygonSlicerOperatorSliceIntoStripsOptionsGenerated } = await import('./polygonSlicerOperatorSliceIntoStripsOptions.gb');
    return await buildDotNetPolygonSlicerOperatorSliceIntoStripsOptionsGenerated(jsObject);
}
