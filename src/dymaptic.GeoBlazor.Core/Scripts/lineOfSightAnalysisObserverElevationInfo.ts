
export async function buildJsLineOfSightAnalysisObserverElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsLineOfSightAnalysisObserverElevationInfoGenerated } = await import('./lineOfSightAnalysisObserverElevationInfo.gb');
    return await buildJsLineOfSightAnalysisObserverElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetLineOfSightAnalysisObserverElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetLineOfSightAnalysisObserverElevationInfoGenerated } = await import('./lineOfSightAnalysisObserverElevationInfo.gb');
    return await buildDotNetLineOfSightAnalysisObserverElevationInfoGenerated(jsObject);
}
