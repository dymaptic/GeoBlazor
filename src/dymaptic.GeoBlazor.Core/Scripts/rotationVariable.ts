
export async function buildJsRotationVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRotationVariableGenerated } = await import('./rotationVariable.gb');
    return await buildJsRotationVariableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRotationVariable(jsObject: any): Promise<any> {
    let { buildDotNetRotationVariableGenerated } = await import('./rotationVariable.gb');
    return await buildDotNetRotationVariableGenerated(jsObject);
}
