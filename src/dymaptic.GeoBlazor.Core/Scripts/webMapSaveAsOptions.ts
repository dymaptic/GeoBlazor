export async function buildJsWebMapSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebMapSaveAsOptionsGenerated } = await import('./webMapSaveAsOptions.gb');
    return await buildJsWebMapSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetWebMapSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetWebMapSaveAsOptionsGenerated } = await import('./webMapSaveAsOptions.gb');
    return await buildDotNetWebMapSaveAsOptionsGenerated(jsObject);
}
