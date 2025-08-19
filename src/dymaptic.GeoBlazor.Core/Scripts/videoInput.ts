
export async function buildJsVideoInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoInputGenerated } = await import('./videoInput.gb');
    return await buildJsVideoInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVideoInputGenerated } = await import('./videoInput.gb');
    return await buildDotNetVideoInputGenerated(jsObject, viewId);
}
