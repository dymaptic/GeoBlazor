
export async function buildJsLineOfSightAnalysisTargetElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsLineOfSightAnalysisTargetElevationInfoGenerated } = await import('./lineOfSightAnalysisTargetElevationInfo.gb');
    return await buildJsLineOfSightAnalysisTargetElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetLineOfSightAnalysisTargetElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetLineOfSightAnalysisTargetElevationInfoGenerated } = await import('./lineOfSightAnalysisTargetElevationInfo.gb');
    return await buildDotNetLineOfSightAnalysisTargetElevationInfoGenerated(jsObject);
}
