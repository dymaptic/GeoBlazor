
export async function buildJsIElevationProfileViewModelProfiles(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIElevationProfileViewModelProfilesGenerated } = await import('./iElevationProfileViewModelProfiles.gb');
    return await buildJsIElevationProfileViewModelProfilesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIElevationProfileViewModelProfiles(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIElevationProfileViewModelProfilesGenerated } = await import('./iElevationProfileViewModelProfiles.gb');
    return await buildDotNetIElevationProfileViewModelProfilesGenerated(jsObject, viewId);
}
