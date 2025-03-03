
export async function buildJsCIMObjectMarker3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMObjectMarker3DGenerated } = await import('./cIMObjectMarker3D.gb');
    return await buildJsCIMObjectMarker3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMObjectMarker3D(jsObject: any): Promise<any> {
    let { buildDotNetCIMObjectMarker3DGenerated } = await import('./cIMObjectMarker3D.gb');
    return await buildDotNetCIMObjectMarker3DGenerated(jsObject);
}
