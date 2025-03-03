
export async function buildJsGamepadSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGamepadSettingsGenerated } = await import('./gamepadSettings.gb');
    return await buildJsGamepadSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGamepadSettings(jsObject: any): Promise<any> {
    let { buildDotNetGamepadSettingsGenerated } = await import('./gamepadSettings.gb');
    return await buildDotNetGamepadSettingsGenerated(jsObject);
}
