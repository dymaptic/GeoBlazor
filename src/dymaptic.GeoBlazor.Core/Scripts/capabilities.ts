
export async function buildJsCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesGenerated } = await import('./capabilities.gb');
    return await buildJsCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesGenerated } = await import('./capabilities.gb');
    return await buildDotNetCapabilitiesGenerated(jsObject);
}
