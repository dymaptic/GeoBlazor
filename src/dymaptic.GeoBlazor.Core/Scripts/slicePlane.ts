export async function buildJsSlicePlane(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSlicePlaneGenerated } = await import('./slicePlane.gb');
    return await buildJsSlicePlaneGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSlicePlane(jsObject: any): Promise<any> {
    let { buildDotNetSlicePlaneGenerated } = await import('./slicePlane.gb');
    return await buildDotNetSlicePlaneGenerated(jsObject);
}
