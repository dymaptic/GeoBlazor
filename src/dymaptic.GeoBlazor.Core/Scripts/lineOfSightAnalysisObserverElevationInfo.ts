
export async function buildJsLineOfSightAnalysisObserverElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLineOfSightAnalysisObserverElevationInfoGenerated } = await import('./lineOfSightAnalysisObserverElevationInfo.gb');
    return await buildJsLineOfSightAnalysisObserverElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLineOfSightAnalysisObserverElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLineOfSightAnalysisObserverElevationInfoGenerated } = await import('./lineOfSightAnalysisObserverElevationInfo.gb');
    return await buildDotNetLineOfSightAnalysisObserverElevationInfoGenerated(jsObject, viewId);
}
