export async function buildJsCoverageDescriptionV110Domain(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV110DomainGenerated} = await import('./coverageDescriptionV110Domain.gb');
    return await buildJsCoverageDescriptionV110DomainGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV110Domain(jsObject: any): Promise<any> {
    let {buildDotNetCoverageDescriptionV110DomainGenerated} = await import('./coverageDescriptionV110Domain.gb');
    return await buildDotNetCoverageDescriptionV110DomainGenerated(jsObject);
}
