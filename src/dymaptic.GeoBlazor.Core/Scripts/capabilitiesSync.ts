
export async function buildJsCapabilitiesSync(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesSyncGenerated } = await import('./capabilitiesSync.gb');
    return await buildJsCapabilitiesSyncGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesSync(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesSyncGenerated } = await import('./capabilitiesSync.gb');
    return await buildDotNetCapabilitiesSyncGenerated(jsObject);
}
