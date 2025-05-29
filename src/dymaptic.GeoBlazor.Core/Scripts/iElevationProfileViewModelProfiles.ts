
export async function buildJsIElevationProfileViewModelProfiles(dotNetObject: any): Promise<any> {
    let { buildJsIElevationProfileViewModelProfilesGenerated } = await import('./iElevationProfileViewModelProfiles.gb');
    return await buildJsIElevationProfileViewModelProfilesGenerated(dotNetObject);
}     

export async function buildDotNetIElevationProfileViewModelProfiles(jsObject: any): Promise<any> {
    let { buildDotNetIElevationProfileViewModelProfilesGenerated } = await import('./iElevationProfileViewModelProfiles.gb');
    return await buildDotNetIElevationProfileViewModelProfilesGenerated(jsObject);
}
