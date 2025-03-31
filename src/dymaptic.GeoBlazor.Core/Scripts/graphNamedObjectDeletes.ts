
export async function buildJsGraphNamedObjectDeletes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphNamedObjectDeletesGenerated } = await import('./graphNamedObjectDeletes.gb');
    return await buildJsGraphNamedObjectDeletesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphNamedObjectDeletes(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGraphNamedObjectDeletesGenerated } = await import('./graphNamedObjectDeletes.gb');
    return await buildDotNetGraphNamedObjectDeletesGenerated(jsObject, layerId, viewId);
}
