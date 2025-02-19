
export async function buildJsInputSetting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsInputSettingGenerated } = await import('./inputSetting.gb');
    return await buildJsInputSettingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetInputSetting(jsObject: any): Promise<any> {
    let { buildDotNetInputSettingGenerated } = await import('./inputSetting.gb');
    return await buildDotNetInputSettingGenerated(jsObject);
}
