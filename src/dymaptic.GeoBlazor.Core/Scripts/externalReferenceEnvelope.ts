
export async function buildJsExternalReferenceEnvelope(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExternalReferenceEnvelopeGenerated } = await import('./externalReferenceEnvelope.gb');
    return await buildJsExternalReferenceEnvelopeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExternalReferenceEnvelope(jsObject: any): Promise<any> {
    let { buildDotNetExternalReferenceEnvelopeGenerated } = await import('./externalReferenceEnvelope.gb');
    return await buildDotNetExternalReferenceEnvelopeGenerated(jsObject);
}
