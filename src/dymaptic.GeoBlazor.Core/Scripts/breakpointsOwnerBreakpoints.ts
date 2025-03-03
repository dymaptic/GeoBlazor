
export async function buildJsBreakpointsOwnerBreakpoints(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBreakpointsOwnerBreakpointsGenerated } = await import('./breakpointsOwnerBreakpoints.gb');
    return await buildJsBreakpointsOwnerBreakpointsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBreakpointsOwnerBreakpoints(jsObject: any): Promise<any> {
    let { buildDotNetBreakpointsOwnerBreakpointsGenerated } = await import('./breakpointsOwnerBreakpoints.gb');
    return await buildDotNetBreakpointsOwnerBreakpointsGenerated(jsObject);
}
