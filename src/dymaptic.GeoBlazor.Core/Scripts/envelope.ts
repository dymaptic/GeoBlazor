
export async function buildJsEnvelope(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEnvelopeGenerated } = await import('./envelope.gb');
    return await buildJsEnvelopeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEnvelope(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEnvelopeGenerated } = await import('./envelope.gb');
    return await buildDotNetEnvelopeGenerated(jsObject, layerId, viewId);
}
