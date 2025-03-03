
export async function buildJsLineOfSightAnalysisTargetElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineOfSightAnalysisTargetElevationInfoGenerated } = await import('./lineOfSightAnalysisTargetElevationInfo.gb');
    return await buildJsLineOfSightAnalysisTargetElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineOfSightAnalysisTargetElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetLineOfSightAnalysisTargetElevationInfoGenerated } = await import('./lineOfSightAnalysisTargetElevationInfo.gb');
    return await buildDotNetLineOfSightAnalysisTargetElevationInfoGenerated(jsObject);
}
