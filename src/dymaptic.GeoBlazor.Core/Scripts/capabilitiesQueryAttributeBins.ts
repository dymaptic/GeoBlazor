
export async function buildJsCapabilitiesQueryAttributeBins(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesQueryAttributeBinsGenerated } = await import('./capabilitiesQueryAttributeBins.gb');
    return await buildJsCapabilitiesQueryAttributeBinsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesQueryAttributeBins(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryAttributeBinsGenerated } = await import('./capabilitiesQueryAttributeBins.gb');
    return await buildDotNetCapabilitiesQueryAttributeBinsGenerated(jsObject);
}
