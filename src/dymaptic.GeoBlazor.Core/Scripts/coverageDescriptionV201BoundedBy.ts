export async function buildJsCoverageDescriptionV201BoundedBy(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV201BoundedByGenerated} = await import('./coverageDescriptionV201BoundedBy.gb');
    return await buildJsCoverageDescriptionV201BoundedByGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV201BoundedBy(jsObject: any): Promise<any> {
    let {buildDotNetCoverageDescriptionV201BoundedByGenerated} = await import('./coverageDescriptionV201BoundedBy.gb');
    return await buildDotNetCoverageDescriptionV201BoundedByGenerated(jsObject);
}
