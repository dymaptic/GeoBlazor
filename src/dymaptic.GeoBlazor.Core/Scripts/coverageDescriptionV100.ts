export async function buildJsCoverageDescriptionV100(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoverageDescriptionV100Generated } = await import('./coverageDescriptionV100.gb');
    return await buildJsCoverageDescriptionV100Generated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCoverageDescriptionV100(jsObject: any): Promise<any> {
    let { buildDotNetCoverageDescriptionV100Generated } = await import('./coverageDescriptionV100.gb');
    return await buildDotNetCoverageDescriptionV100Generated(jsObject);
}
