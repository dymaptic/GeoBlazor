
export async function buildJsCapabilitiesQueryRelated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesQueryRelatedGenerated } = await import('./capabilitiesQueryRelated.gb');
    return await buildJsCapabilitiesQueryRelatedGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesQueryRelated(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryRelatedGenerated } = await import('./capabilitiesQueryRelated.gb');
    return await buildDotNetCapabilitiesQueryRelatedGenerated(jsObject);
}
