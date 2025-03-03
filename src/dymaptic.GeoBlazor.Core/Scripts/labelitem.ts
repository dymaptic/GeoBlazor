
export async function buildJsLabelitem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLabelitemGenerated } = await import('./labelitem.gb');
    return await buildJsLabelitemGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLabelitem(jsObject: any): Promise<any> {
    let { buildDotNetLabelitemGenerated } = await import('./labelitem.gb');
    return await buildDotNetLabelitemGenerated(jsObject);
}
