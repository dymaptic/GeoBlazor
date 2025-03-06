
export async function buildJsPopupDockOptionsBreakpoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupDockOptionsBreakpointGenerated } = await import('./popupDockOptionsBreakpoint.gb');
    return await buildJsPopupDockOptionsBreakpointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPopupDockOptionsBreakpoint(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPopupDockOptionsBreakpointGenerated } = await import('./popupDockOptionsBreakpoint.gb');
    return await buildDotNetPopupDockOptionsBreakpointGenerated(jsObject, layerId, viewId);
}
