
export async function buildJsCoverageDescriptionV201EoMetadataObservation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoverageDescriptionV201EoMetadataObservationGenerated } = await import('./coverageDescriptionV201EoMetadataObservation.gb');
    return await buildJsCoverageDescriptionV201EoMetadataObservationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoverageDescriptionV201EoMetadataObservation(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCoverageDescriptionV201EoMetadataObservationGenerated } = await import('./coverageDescriptionV201EoMetadataObservation.gb');
    return await buildDotNetCoverageDescriptionV201EoMetadataObservationGenerated(jsObject, viewId);
}
