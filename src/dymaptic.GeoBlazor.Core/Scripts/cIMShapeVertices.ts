
export async function buildJsCIMShapeVertices(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMShapeVerticesGenerated } = await import('./cIMShapeVertices.gb');
    return await buildJsCIMShapeVerticesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMShapeVertices(jsObject: any): Promise<any> {
    let { buildDotNetCIMShapeVerticesGenerated } = await import('./cIMShapeVertices.gb');
    return await buildDotNetCIMShapeVerticesGenerated(jsObject);
}
