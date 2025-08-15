
export async function buildJsIElevationProfileWidgetProfiles(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIElevationProfileWidgetProfilesGenerated } = await import('./iElevationProfileWidgetProfiles.gb');
    return await buildJsIElevationProfileWidgetProfilesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIElevationProfileWidgetProfiles(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIElevationProfileWidgetProfilesGenerated } = await import('./iElevationProfileWidgetProfiles.gb');
    return await buildDotNetIElevationProfileWidgetProfilesGenerated(jsObject, viewId);
}
