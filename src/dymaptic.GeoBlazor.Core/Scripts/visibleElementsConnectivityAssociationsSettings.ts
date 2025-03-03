
export async function buildJsVisibleElementsConnectivityAssociationsSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsConnectivityAssociationsSettingsGenerated } = await import('./visibleElementsConnectivityAssociationsSettings.gb');
    return await buildJsVisibleElementsConnectivityAssociationsSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsConnectivityAssociationsSettings(jsObject: any): Promise<any> {
    let { buildDotNetVisibleElementsConnectivityAssociationsSettingsGenerated } = await import('./visibleElementsConnectivityAssociationsSettings.gb');
    return await buildDotNetVisibleElementsConnectivityAssociationsSettingsGenerated(jsObject);
}
