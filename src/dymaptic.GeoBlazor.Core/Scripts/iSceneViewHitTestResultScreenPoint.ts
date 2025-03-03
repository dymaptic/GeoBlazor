
export async function buildJsISceneViewHitTestResultScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISceneViewHitTestResultScreenPointGenerated } = await import('./iSceneViewHitTestResultScreenPoint.gb');
    return await buildJsISceneViewHitTestResultScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISceneViewHitTestResultScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetISceneViewHitTestResultScreenPointGenerated } = await import('./iSceneViewHitTestResultScreenPoint.gb');
    return await buildDotNetISceneViewHitTestResultScreenPointGenerated(jsObject);
}
