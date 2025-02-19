export async function buildJsSelectionChangeEventInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSelectionChangeEventInfoGenerated } = await import('./selectionChangeEventInfo.gb');
    return await buildJsSelectionChangeEventInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSelectionChangeEventInfo(jsObject: any): Promise<any> {
    let { buildDotNetSelectionChangeEventInfoGenerated } = await import('./selectionChangeEventInfo.gb');
    return await buildDotNetSelectionChangeEventInfoGenerated(jsObject);
}
