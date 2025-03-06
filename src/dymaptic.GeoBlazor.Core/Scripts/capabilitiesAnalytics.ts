
export async function buildJsCapabilitiesAnalytics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesAnalyticsGenerated } = await import('./capabilitiesAnalytics.gb');
    return await buildJsCapabilitiesAnalyticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesAnalytics(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCapabilitiesAnalyticsGenerated } = await import('./capabilitiesAnalytics.gb');
    return await buildDotNetCapabilitiesAnalyticsGenerated(jsObject, layerId, viewId);
}
