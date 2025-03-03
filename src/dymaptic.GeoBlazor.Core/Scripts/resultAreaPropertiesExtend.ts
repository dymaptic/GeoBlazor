
export async function buildJsResultAreaPropertiesExtend(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsResultAreaPropertiesExtendGenerated } = await import('./resultAreaPropertiesExtend.gb');
    return await buildJsResultAreaPropertiesExtendGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetResultAreaPropertiesExtend(jsObject: any): Promise<any> {
    let { buildDotNetResultAreaPropertiesExtendGenerated } = await import('./resultAreaPropertiesExtend.gb');
    return await buildDotNetResultAreaPropertiesExtendGenerated(jsObject);
}
