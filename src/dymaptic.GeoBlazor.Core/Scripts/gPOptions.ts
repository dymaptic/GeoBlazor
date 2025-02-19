export async function buildJsGPOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGPOptionsGenerated } = await import('./gPOptions.gb');
    return await buildJsGPOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetGPOptions(jsObject: any): Promise<any> {
    let { buildDotNetGPOptionsGenerated } = await import('./gPOptions.gb');
    return await buildDotNetGPOptionsGenerated(jsObject);
}
