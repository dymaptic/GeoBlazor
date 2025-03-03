
export async function buildJsIRouteStopSymbolsWaypoint(dotNetObject: any): Promise<any> {
    let { buildJsIRouteStopSymbolsWaypointGenerated } = await import('./iRouteStopSymbolsWaypoint.gb');
    return await buildJsIRouteStopSymbolsWaypointGenerated(dotNetObject);
}     

export async function buildDotNetIRouteStopSymbolsWaypoint(jsObject: any): Promise<any> {
    let { buildDotNetIRouteStopSymbolsWaypointGenerated } = await import('./iRouteStopSymbolsWaypoint.gb');
    return await buildDotNetIRouteStopSymbolsWaypointGenerated(jsObject);
}
