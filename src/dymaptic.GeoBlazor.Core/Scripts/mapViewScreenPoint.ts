
export async function buildJsMapViewScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapViewScreenPointGenerated } = await import('./mapViewScreenPoint.gb');
    return await buildJsMapViewScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapViewScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetMapViewScreenPointGenerated } = await import('./mapViewScreenPoint.gb');
    return await buildDotNetMapViewScreenPointGenerated(jsObject);
}
