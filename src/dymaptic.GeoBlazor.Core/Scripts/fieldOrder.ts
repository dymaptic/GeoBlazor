
export async function buildJsFieldOrder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldOrderGenerated } = await import('./fieldOrder.gb');
    return await buildJsFieldOrderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldOrder(jsObject: any): Promise<any> {
    let { buildDotNetFieldOrderGenerated } = await import('./fieldOrder.gb');
    return await buildDotNetFieldOrderGenerated(jsObject);
}
