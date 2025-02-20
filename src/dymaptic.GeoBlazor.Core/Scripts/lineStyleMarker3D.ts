export async function buildJsLineStyleMarker3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineStyleMarker3DGenerated} = await import('./lineStyleMarker3D.gb');
    return await buildJsLineStyleMarker3DGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineStyleMarker3D(jsObject: any): Promise<any> {
    let {buildDotNetLineStyleMarker3DGenerated} = await import('./lineStyleMarker3D.gb');
    return await buildDotNetLineStyleMarker3DGenerated(jsObject);
}
