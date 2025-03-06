
export async function buildJsSolidEdges3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSolidEdges3DGenerated } = await import('./solidEdges3D.gb');
    return await buildJsSolidEdges3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSolidEdges3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSolidEdges3DGenerated } = await import('./solidEdges3D.gb');
    return await buildDotNetSolidEdges3DGenerated(jsObject, layerId, viewId);
}
