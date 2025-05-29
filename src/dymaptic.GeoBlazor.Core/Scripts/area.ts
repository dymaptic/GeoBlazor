
export async function buildJsArea(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaGenerated } = await import('./area.gb');
    return await buildJsAreaGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetArea(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAreaGenerated } = await import('./area.gb');
    return await buildDotNetAreaGenerated(jsObject, layerId, viewId);
}
