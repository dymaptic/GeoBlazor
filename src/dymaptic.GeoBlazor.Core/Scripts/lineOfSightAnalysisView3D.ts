export async function buildJsLineOfSightAnalysisView3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineOfSightAnalysisView3DGenerated} = await import('./lineOfSightAnalysisView3D.gb');
    return await buildJsLineOfSightAnalysisView3DGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineOfSightAnalysisView3D(jsObject: any): Promise<any> {
    let {buildDotNetLineOfSightAnalysisView3DGenerated} = await import('./lineOfSightAnalysisView3D.gb');
    return await buildDotNetLineOfSightAnalysisView3DGenerated(jsObject);
}
