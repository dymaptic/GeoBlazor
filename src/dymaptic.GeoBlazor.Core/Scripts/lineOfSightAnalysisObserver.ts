
export async function buildJsLineOfSightAnalysisObserver(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineOfSightAnalysisObserverGenerated } = await import('./lineOfSightAnalysisObserver.gb');
    return await buildJsLineOfSightAnalysisObserverGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineOfSightAnalysisObserver(jsObject: any): Promise<any> {
    let { buildDotNetLineOfSightAnalysisObserverGenerated } = await import('./lineOfSightAnalysisObserver.gb');
    return await buildDotNetLineOfSightAnalysisObserverGenerated(jsObject);
}
