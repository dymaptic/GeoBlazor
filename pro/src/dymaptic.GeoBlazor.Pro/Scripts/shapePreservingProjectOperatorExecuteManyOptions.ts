
export async function buildJsShapePreservingProjectOperatorExecuteManyOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShapePreservingProjectOperatorExecuteManyOptionsGenerated } = await import('./shapePreservingProjectOperatorExecuteManyOptions.gb');
    return await buildJsShapePreservingProjectOperatorExecuteManyOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShapePreservingProjectOperatorExecuteManyOptions(jsObject: any): Promise<any> {
    let { buildDotNetShapePreservingProjectOperatorExecuteManyOptionsGenerated } = await import('./shapePreservingProjectOperatorExecuteManyOptions.gb');
    return await buildDotNetShapePreservingProjectOperatorExecuteManyOptionsGenerated(jsObject);
}
