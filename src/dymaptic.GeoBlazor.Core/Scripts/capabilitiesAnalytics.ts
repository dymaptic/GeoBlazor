
export async function buildJsCapabilitiesAnalytics(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesAnalyticsGenerated } = await import('./capabilitiesAnalytics.gb');
    return await buildJsCapabilitiesAnalyticsGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesAnalytics(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesAnalyticsGenerated } = await import('./capabilitiesAnalytics.gb');
    return await buildDotNetCapabilitiesAnalyticsGenerated(jsObject);
}
