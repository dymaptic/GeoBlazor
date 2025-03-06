
export async function buildJsLength(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLengthGenerated } = await import('./length.gb');
    return await buildJsLengthGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLength(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLengthGenerated } = await import('./length.gb');
    return await buildDotNetLengthGenerated(jsObject, layerId, viewId);
}
