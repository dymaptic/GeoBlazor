export async function buildJsLineOfSightAnalysisResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineOfSightAnalysisResultGenerated} = await import('./lineOfSightAnalysisResult.gb');
    return await buildJsLineOfSightAnalysisResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineOfSightAnalysisResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLineOfSightAnalysisResultGenerated} = await import('./lineOfSightAnalysisResult.gb');
    return await buildDotNetLineOfSightAnalysisResultGenerated(jsObject, layerId, viewId);
}
