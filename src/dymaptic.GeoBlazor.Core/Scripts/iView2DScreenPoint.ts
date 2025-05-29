
export async function buildJsIView2DScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIView2DScreenPointGenerated } = await import('./iView2DScreenPoint.gb');
    return await buildJsIView2DScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIView2DScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetIView2DScreenPointGenerated } = await import('./iView2DScreenPoint.gb');
    return await buildDotNetIView2DScreenPointGenerated(jsObject);
}
