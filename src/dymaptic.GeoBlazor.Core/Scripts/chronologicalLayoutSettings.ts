
export async function buildJsChronologicalLayoutSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsChronologicalLayoutSettingsGenerated } = await import('./chronologicalLayoutSettings.gb');
    return await buildJsChronologicalLayoutSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetChronologicalLayoutSettings(jsObject: any): Promise<any> {
    let { buildDotNetChronologicalLayoutSettingsGenerated } = await import('./chronologicalLayoutSettings.gb');
    return await buildDotNetChronologicalLayoutSettingsGenerated(jsObject);
}
