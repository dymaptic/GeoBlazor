export async function buildJsSizeCreateVisualVariablesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeCreateVisualVariablesParamsGenerated} = await import('./sizeCreateVisualVariablesParams.gb');
    return await buildJsSizeCreateVisualVariablesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeCreateVisualVariablesParams(jsObject: any): Promise<any> {
    let {buildDotNetSizeCreateVisualVariablesParamsGenerated} = await import('./sizeCreateVisualVariablesParams.gb');
    return await buildDotNetSizeCreateVisualVariablesParamsGenerated(jsObject);
}
