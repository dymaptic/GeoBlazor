
export async function buildJsIElevationProfileWidgetProfiles(dotNetObject: any): Promise<any> {
    let { buildJsIElevationProfileWidgetProfilesGenerated } = await import('./iElevationProfileWidgetProfiles.gb');
    return await buildJsIElevationProfileWidgetProfilesGenerated(dotNetObject);
}     

export async function buildDotNetIElevationProfileWidgetProfiles(jsObject: any): Promise<any> {
    let { buildDotNetIElevationProfileWidgetProfilesGenerated } = await import('./iElevationProfileWidgetProfiles.gb');
    return await buildDotNetIElevationProfileWidgetProfilesGenerated(jsObject);
}
