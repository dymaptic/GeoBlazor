export async function buildJsLineOfSightAnalysisTarget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineOfSightAnalysisTargetGenerated} = await import('./lineOfSightAnalysisTarget.gb');
    return await buildJsLineOfSightAnalysisTargetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineOfSightAnalysisTarget(jsObject: any): Promise<any> {
    let {buildDotNetLineOfSightAnalysisTargetGenerated} = await import('./lineOfSightAnalysisTarget.gb');
    return await buildDotNetLineOfSightAnalysisTargetGenerated(jsObject);
}
