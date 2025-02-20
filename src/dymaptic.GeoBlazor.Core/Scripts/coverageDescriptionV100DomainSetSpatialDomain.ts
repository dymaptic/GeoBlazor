export async function buildJsCoverageDescriptionV100DomainSetSpatialDomain(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV100DomainSetSpatialDomainGenerated} = await import('./coverageDescriptionV100DomainSetSpatialDomain.gb');
    return await buildJsCoverageDescriptionV100DomainSetSpatialDomainGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV100DomainSetSpatialDomain(jsObject: any): Promise<any> {
    let {buildDotNetCoverageDescriptionV100DomainSetSpatialDomainGenerated} = await import('./coverageDescriptionV100DomainSetSpatialDomain.gb');
    return await buildDotNetCoverageDescriptionV100DomainSetSpatialDomainGenerated(jsObject);
}
