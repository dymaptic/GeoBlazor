
export async function buildJsSnappingOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnappingOptionsGenerated } = await import('./snappingOptions.gb');
    return await buildJsSnappingOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnappingOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSnappingOptionsGenerated } = await import('./snappingOptions.gb');
    return await buildDotNetSnappingOptionsGenerated(jsObject, viewId);
}
