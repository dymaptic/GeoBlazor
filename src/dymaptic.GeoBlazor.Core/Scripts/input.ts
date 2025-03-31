
export async function buildJsInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsInputGenerated } = await import('./input.gb');
    return await buildJsInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetInput(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetInputGenerated } = await import('./input.gb');
    return await buildDotNetInputGenerated(jsObject, layerId, viewId);
}
