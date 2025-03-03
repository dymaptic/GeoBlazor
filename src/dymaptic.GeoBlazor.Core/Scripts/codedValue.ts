
export async function buildJsCodedValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCodedValueGenerated } = await import('./codedValue.gb');
    return await buildJsCodedValueGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCodedValue(jsObject: any): Promise<any> {
    let { buildDotNetCodedValueGenerated } = await import('./codedValue.gb');
    return await buildDotNetCodedValueGenerated(jsObject);
}
