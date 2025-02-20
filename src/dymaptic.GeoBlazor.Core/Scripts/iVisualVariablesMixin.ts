export async function buildJsIVisualVariablesMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIVisualVariablesMixinGenerated} = await import('./iVisualVariablesMixin.gb');
    return await buildJsIVisualVariablesMixinGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIVisualVariablesMixin(jsObject: any): Promise<any> {
    let {buildDotNetIVisualVariablesMixinGenerated} = await import('./iVisualVariablesMixin.gb');
    return await buildDotNetIVisualVariablesMixinGenerated(jsObject);
}
