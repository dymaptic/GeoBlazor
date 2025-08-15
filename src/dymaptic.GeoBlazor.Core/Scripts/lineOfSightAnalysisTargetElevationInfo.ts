
export async function buildJsLineOfSightAnalysisTargetElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLineOfSightAnalysisTargetElevationInfoGenerated } = await import('./lineOfSightAnalysisTargetElevationInfo.gb');
    return await buildJsLineOfSightAnalysisTargetElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLineOfSightAnalysisTargetElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLineOfSightAnalysisTargetElevationInfoGenerated } = await import('./lineOfSightAnalysisTargetElevationInfo.gb');
    return await buildDotNetLineOfSightAnalysisTargetElevationInfoGenerated(jsObject, viewId);
}
