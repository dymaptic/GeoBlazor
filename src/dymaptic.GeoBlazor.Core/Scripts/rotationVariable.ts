export async function buildJsRotationVariable(dotNetObject: any): Promise<any> {
    let {buildJsRotationVariableGenerated} = await import('./rotationVariable.gb');
    return await buildJsRotationVariableGenerated(dotNetObject);
}

export async function buildDotNetRotationVariable(jsObject: any): Promise<any> {
    let {buildDotNetRotationVariableGenerated} = await import('./rotationVariable.gb');
    return await buildDotNetRotationVariableGenerated(jsObject);
}
