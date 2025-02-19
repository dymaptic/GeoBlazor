export async function buildJsViewHoldEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewHoldEventGenerated } = await import('./viewHoldEvent.gb');
    return await buildJsViewHoldEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetViewHoldEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewHoldEventGenerated } = await import('./viewHoldEvent.gb');
    return await buildDotNetViewHoldEventGenerated(jsObject);
}
