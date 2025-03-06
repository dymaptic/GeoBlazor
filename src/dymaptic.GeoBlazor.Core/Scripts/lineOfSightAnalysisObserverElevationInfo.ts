
export async function buildJsLineOfSightAnalysisObserverElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineOfSightAnalysisObserverElevationInfoGenerated } = await import('./lineOfSightAnalysisObserverElevationInfo.gb');
    return await buildJsLineOfSightAnalysisObserverElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineOfSightAnalysisObserverElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLineOfSightAnalysisObserverElevationInfoGenerated } = await import('./lineOfSightAnalysisObserverElevationInfo.gb');
    return await buildDotNetLineOfSightAnalysisObserverElevationInfoGenerated(jsObject, layerId, viewId);
}
