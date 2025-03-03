
export async function buildJsCIMObjectMarker3DLOD(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMObjectMarker3DLODGenerated } = await import('./cIMObjectMarker3DLOD.gb');
    return await buildJsCIMObjectMarker3DLODGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMObjectMarker3DLOD(jsObject: any): Promise<any> {
    let { buildDotNetCIMObjectMarker3DLODGenerated } = await import('./cIMObjectMarker3DLOD.gb');
    return await buildDotNetCIMObjectMarker3DLODGenerated(jsObject);
}
