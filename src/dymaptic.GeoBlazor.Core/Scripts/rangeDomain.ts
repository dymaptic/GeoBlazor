
export async function buildJsRangeDomain(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRangeDomainGenerated } = await import('./rangeDomain.gb');
    return await buildJsRangeDomainGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRangeDomain(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRangeDomainGenerated } = await import('./rangeDomain.gb');
    return await buildDotNetRangeDomainGenerated(jsObject, layerId, viewId);
}
