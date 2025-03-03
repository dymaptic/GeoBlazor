
export async function buildJsBaseLayerViewGL2DTile(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBaseLayerViewGL2DTileGenerated } = await import('./baseLayerViewGL2DTile.gb');
    return await buildJsBaseLayerViewGL2DTileGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBaseLayerViewGL2DTile(jsObject: any): Promise<any> {
    let { buildDotNetBaseLayerViewGL2DTileGenerated } = await import('./baseLayerViewGL2DTile.gb');
    return await buildDotNetBaseLayerViewGL2DTileGenerated(jsObject);
}
