
export async function buildJsBaseLayerViewGL2DScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBaseLayerViewGL2DScreenPointGenerated } = await import('./baseLayerViewGL2DScreenPoint.gb');
    return await buildJsBaseLayerViewGL2DScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBaseLayerViewGL2DScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetBaseLayerViewGL2DScreenPointGenerated } = await import('./baseLayerViewGL2DScreenPoint.gb');
    return await buildDotNetBaseLayerViewGL2DScreenPointGenerated(jsObject);
}
