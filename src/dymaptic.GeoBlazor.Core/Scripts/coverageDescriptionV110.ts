
export async function buildJsCoverageDescriptionV110(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoverageDescriptionV110Generated } = await import('./coverageDescriptionV110.gb');
    return await buildJsCoverageDescriptionV110Generated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoverageDescriptionV110(jsObject: any): Promise<any> {
    let { buildDotNetCoverageDescriptionV110Generated } = await import('./coverageDescriptionV110.gb');
    return await buildDotNetCoverageDescriptionV110Generated(jsObject);
}
