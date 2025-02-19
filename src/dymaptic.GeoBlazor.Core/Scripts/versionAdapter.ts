
export async function buildJsVersionAdapter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVersionAdapterGenerated } = await import('./versionAdapter.gb');
    return await buildJsVersionAdapterGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVersionAdapter(jsObject: any): Promise<any> {
    let { buildDotNetVersionAdapterGenerated } = await import('./versionAdapter.gb');
    return await buildDotNetVersionAdapterGenerated(jsObject);
}
