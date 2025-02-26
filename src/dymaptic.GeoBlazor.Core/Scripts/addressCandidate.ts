
export async function buildJsAddressCandidate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAddressCandidateGenerated } = await import('./addressCandidate.gb');
    return await buildJsAddressCandidateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAddressCandidate(jsObject: any): Promise<any> {
    let { buildDotNetAddressCandidateGenerated } = await import('./addressCandidate.gb');
    return await buildDotNetAddressCandidateGenerated(jsObject);
}
