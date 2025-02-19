
export async function buildJsFormatPosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFormatPositionGenerated } = await import('./formatPosition.gb');
    return await buildJsFormatPositionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFormatPosition(jsObject: any): Promise<any> {
    let { buildDotNetFormatPositionGenerated } = await import('./formatPosition.gb');
    return await buildDotNetFormatPositionGenerated(jsObject);
}
