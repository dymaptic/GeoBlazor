export async function buildJsCoverageDescriptionV110DomainSpatialDomain(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV110DomainSpatialDomainGenerated} = await import('./coverageDescriptionV110DomainSpatialDomain.gb');
    return await buildJsCoverageDescriptionV110DomainSpatialDomainGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV110DomainSpatialDomain(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetCoverageDescriptionV110DomainSpatialDomainGenerated} = await import('./coverageDescriptionV110DomainSpatialDomain.gb');
    return await buildDotNetCoverageDescriptionV110DomainSpatialDomainGenerated(jsObject, layerId, viewId);
}
