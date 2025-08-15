
export async function buildJsIBuildingFilterBlockFilterModeEdges(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIBuildingFilterBlockFilterModeEdgesGenerated } = await import('./iBuildingFilterBlockFilterModeEdges.gb');
    return await buildJsIBuildingFilterBlockFilterModeEdgesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIBuildingFilterBlockFilterModeEdges(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIBuildingFilterBlockFilterModeEdgesGenerated } = await import('./iBuildingFilterBlockFilterModeEdges.gb');
    return await buildDotNetIBuildingFilterBlockFilterModeEdgesGenerated(jsObject, viewId);
}
