export async function buildJsEdges3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEdges3DGenerated} = await import('./edges3D.gb');
    return await buildJsEdges3DGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEdges3D(jsObject: any): Promise<any> {
    let {buildDotNetEdges3DGenerated} = await import('./edges3D.gb');
    return await buildDotNetEdges3DGenerated(jsObject);
}
