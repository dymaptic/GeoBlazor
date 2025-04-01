
export async function buildJsSceneViewScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewScreenPointGenerated } = await import('./sceneViewScreenPoint.gb');
    return await buildJsSceneViewScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewScreenPoint(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewScreenPointGenerated } = await import('./sceneViewScreenPoint.gb');
    return await buildDotNetSceneViewScreenPointGenerated(jsObject, layerId, viewId);
}
