
export async function buildJsSketchEdges3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchEdges3DGenerated } = await import('./sketchEdges3D.gb');
    return await buildJsSketchEdges3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchEdges3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchEdges3DGenerated } = await import('./sketchEdges3D.gb');
    return await buildDotNetSketchEdges3DGenerated(jsObject, layerId, viewId);
}
