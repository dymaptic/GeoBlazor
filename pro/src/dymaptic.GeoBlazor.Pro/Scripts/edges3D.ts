
export async function buildJsEdges3D(dotNetObject: any): Promise<any> {
    let { buildJsEdges3DGenerated } = await import('./edges3D.gb');
    return buildJsEdges3DGenerated(dotNetObject);
}     

export async function buildDotNetEdges3D(jsObject: any): Promise<any> {
    let { buildDotNetEdges3DGenerated } = await import('./edges3D.gb');
    return await buildDotNetEdges3DGenerated(jsObject);
}
