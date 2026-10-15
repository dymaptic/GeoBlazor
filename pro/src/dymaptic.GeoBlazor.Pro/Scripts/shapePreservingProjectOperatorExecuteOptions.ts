
export async function buildJsShapePreservingProjectOperatorExecuteOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShapePreservingProjectOperatorExecuteOptionsGenerated } = await import('./shapePreservingProjectOperatorExecuteOptions.gb');
    return await buildJsShapePreservingProjectOperatorExecuteOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShapePreservingProjectOperatorExecuteOptions(jsObject: any): Promise<any> {
    let { buildDotNetShapePreservingProjectOperatorExecuteOptionsGenerated } = await import('./shapePreservingProjectOperatorExecuteOptions.gb');
    return await buildDotNetShapePreservingProjectOperatorExecuteOptionsGenerated(jsObject);
}
