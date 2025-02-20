export async function buildJsOpacityVisualVariableResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsOpacityVisualVariableResultGenerated} = await import('./opacityVisualVariableResult.gb');
    return await buildJsOpacityVisualVariableResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetOpacityVisualVariableResult(jsObject: any): Promise<any> {
    let {buildDotNetOpacityVisualVariableResultGenerated} = await import('./opacityVisualVariableResult.gb');
    return await buildDotNetOpacityVisualVariableResultGenerated(jsObject);
}
