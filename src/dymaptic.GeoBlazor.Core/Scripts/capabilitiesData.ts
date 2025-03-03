
export async function buildJsCapabilitiesData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesDataGenerated } = await import('./capabilitiesData.gb');
    return await buildJsCapabilitiesDataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesData(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesDataGenerated } = await import('./capabilitiesData.gb');
    return await buildDotNetCapabilitiesDataGenerated(jsObject);
}
