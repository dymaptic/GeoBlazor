
export async function buildJsImageInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageInputGenerated } = await import('./imageInput.gb');
    return await buildJsImageInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetImageInputGenerated } = await import('./imageInput.gb');
    return await buildDotNetImageInputGenerated(jsObject, viewId);
}
