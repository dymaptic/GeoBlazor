
export async function buildJsOrganicLayoutSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrganicLayoutSettingsGenerated } = await import('./organicLayoutSettings.gb');
    return await buildJsOrganicLayoutSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrganicLayoutSettings(jsObject: any): Promise<any> {
    let { buildDotNetOrganicLayoutSettingsGenerated } = await import('./organicLayoutSettings.gb');
    return await buildDotNetOrganicLayoutSettingsGenerated(jsObject);
}
