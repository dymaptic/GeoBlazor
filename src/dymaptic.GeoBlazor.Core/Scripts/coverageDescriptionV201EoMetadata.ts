export async function buildJsCoverageDescriptionV201EoMetadata(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoverageDescriptionV201EoMetadataGenerated} = await import('./coverageDescriptionV201EoMetadata.gb');
    return await buildJsCoverageDescriptionV201EoMetadataGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoverageDescriptionV201EoMetadata(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetCoverageDescriptionV201EoMetadataGenerated} = await import('./coverageDescriptionV201EoMetadata.gb');
    return await buildDotNetCoverageDescriptionV201EoMetadataGenerated(jsObject, layerId, viewId);
}
