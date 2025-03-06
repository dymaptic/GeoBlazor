
export async function buildJsIBreakpointsOwner(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIBreakpointsOwnerGenerated } = await import('./iBreakpointsOwner.gb');
    return await buildJsIBreakpointsOwnerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIBreakpointsOwner(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIBreakpointsOwnerGenerated } = await import('./iBreakpointsOwner.gb');
    return await buildDotNetIBreakpointsOwnerGenerated(jsObject, layerId, viewId);
}
