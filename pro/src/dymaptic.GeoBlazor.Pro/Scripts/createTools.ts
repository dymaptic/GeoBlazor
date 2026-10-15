
export async function buildJsCreateTools(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCreateToolsGenerated } = await import('./createTools.gb');
    return await buildJsCreateToolsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCreateTools(jsObject: any): Promise<any> {
    let { buildDotNetCreateToolsGenerated } = await import('./createTools.gb');
    return await buildDotNetCreateToolsGenerated(jsObject);
}
