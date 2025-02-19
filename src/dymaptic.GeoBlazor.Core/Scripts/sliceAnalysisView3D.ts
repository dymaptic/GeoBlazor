
export async function buildJsSliceAnalysisView3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSliceAnalysisView3DGenerated } = await import('./sliceAnalysisView3D.gb');
    return await buildJsSliceAnalysisView3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSliceAnalysisView3D(jsObject: any): Promise<any> {
    let { buildDotNetSliceAnalysisView3DGenerated } = await import('./sliceAnalysisView3D.gb');
    return await buildDotNetSliceAnalysisView3DGenerated(jsObject);
}
