
export async function buildJsLayoutSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayoutSettingsGenerated } = await import('./layoutSettings.gb');
    return await buildJsLayoutSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayoutSettings(jsObject: any): Promise<any> {
    let { buildDotNetLayoutSettingsGenerated } = await import('./layoutSettings.gb');
    return await buildDotNetLayoutSettingsGenerated(jsObject);
}
