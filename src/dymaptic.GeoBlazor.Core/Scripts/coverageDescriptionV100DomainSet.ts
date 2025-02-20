export async function buildJsCoverageDescriptionV100DomainSet(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV100DomainSetGenerated} = await import('./coverageDescriptionV100DomainSet.gb');
    return await buildJsCoverageDescriptionV100DomainSetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV100DomainSet(jsObject: any): Promise<any> {
    let {buildDotNetCoverageDescriptionV100DomainSetGenerated} = await import('./coverageDescriptionV100DomainSet.gb');
    return await buildDotNetCoverageDescriptionV100DomainSetGenerated(jsObject);
}
