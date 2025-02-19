export async function buildJsGroupInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupInputGenerated } = await import('./groupInput.gb');
    return await buildJsGroupInputGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetGroupInput(jsObject: any): Promise<any> {
    let { buildDotNetGroupInputGenerated } = await import('./groupInput.gb');
    return await buildDotNetGroupInputGenerated(jsObject);
}
