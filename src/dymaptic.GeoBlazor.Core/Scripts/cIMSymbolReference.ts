export async function buildJsCIMSymbolReference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCIMSymbolReferenceGenerated} = await import('./cIMSymbolReference.gb');
    return await buildJsCIMSymbolReferenceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCIMSymbolReference(jsObject: any): Promise<any> {
    let {buildDotNetCIMSymbolReferenceGenerated} = await import('./cIMSymbolReference.gb');
    return await buildDotNetCIMSymbolReferenceGenerated(jsObject);
}
