
export async function buildJsGamepadGamepadSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGamepadGamepadSettingsGenerated } = await import('./gamepadGamepadSettings.gb');
    return await buildJsGamepadGamepadSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGamepadGamepadSettings(jsObject: any): Promise<any> {
    let { buildDotNetGamepadGamepadSettingsGenerated } = await import('./gamepadGamepadSettings.gb');
    return await buildDotNetGamepadGamepadSettingsGenerated(jsObject);
}
