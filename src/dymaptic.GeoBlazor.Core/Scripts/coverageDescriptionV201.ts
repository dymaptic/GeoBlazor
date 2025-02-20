export async function buildJsCoverageDescriptionV201(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV201Generated} = await import('./coverageDescriptionV201.gb');
    return await buildJsCoverageDescriptionV201Generated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV201(jsObject: any): Promise<any> {
    let {buildDotNetCoverageDescriptionV201Generated} = await import('./coverageDescriptionV201.gb');
    return await buildDotNetCoverageDescriptionV201Generated(jsObject);
}
