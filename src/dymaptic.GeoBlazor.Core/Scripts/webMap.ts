
export async function buildJsWebMap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebMapGenerated } = await import('./webMap.gb');
    return await buildJsWebMapGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebMap(jsObject: any): Promise<any> {
    let { buildDotNetWebMapGenerated } = await import('./webMap.gb');
    return await buildDotNetWebMapGenerated(jsObject);
}
