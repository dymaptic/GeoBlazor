// override generated code in this file

export async function buildJsImageAngleParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageAngleParametersGenerated} = await import('./imageAngleParameters.gb');
    return await buildJsImageAngleParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageAngleParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageAngleParametersGenerated} = await import('./imageAngleParameters.gb');
    return await buildDotNetImageAngleParametersGenerated(jsObject, layerId, viewId);
}
