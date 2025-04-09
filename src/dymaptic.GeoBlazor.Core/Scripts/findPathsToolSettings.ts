
export async function buildJsFindPathsToolSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFindPathsToolSettingsGenerated } = await import('./findPathsToolSettings.gb');
    return await buildJsFindPathsToolSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFindPathsToolSettings(jsObject: any): Promise<any> {
    let { buildDotNetFindPathsToolSettingsGenerated } = await import('./findPathsToolSettings.gb');
    return await buildDotNetFindPathsToolSettingsGenerated(jsObject);
}
