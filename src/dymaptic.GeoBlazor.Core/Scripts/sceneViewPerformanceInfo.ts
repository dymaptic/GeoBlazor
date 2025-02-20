export async function buildJsSceneViewPerformanceInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneViewPerformanceInfoGenerated} = await import('./sceneViewPerformanceInfo.gb');
    return await buildJsSceneViewPerformanceInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneViewPerformanceInfo(jsObject: any): Promise<any> {
    let {buildDotNetSceneViewPerformanceInfoGenerated} = await import('./sceneViewPerformanceInfo.gb');
    return await buildDotNetSceneViewPerformanceInfoGenerated(jsObject);
}
