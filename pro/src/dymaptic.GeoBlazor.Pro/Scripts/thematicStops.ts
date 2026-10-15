
export async function buildJsThematicStops(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsThematicStopsGenerated } = await import('./thematicStops.gb');
    return await buildJsThematicStopsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetThematicStops(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetThematicStopsGenerated } = await import('./thematicStops.gb');
    return await buildDotNetThematicStopsGenerated(jsObject, layerId, viewId);
}
