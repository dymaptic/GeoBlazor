
export async function buildJsDocumentInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDocumentInputGenerated } = await import('./documentInput.gb');
    return await buildJsDocumentInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDocumentInput(jsObject: any): Promise<any> {
    let { buildDotNetDocumentInputGenerated } = await import('./documentInput.gb');
    return await buildDotNetDocumentInputGenerated(jsObject);
}
