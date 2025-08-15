
export async function buildJsIVisualVariablesMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIVisualVariablesMixinGenerated } = await import('./iVisualVariablesMixin.gb');
    return await buildJsIVisualVariablesMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIVisualVariablesMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIVisualVariablesMixinGenerated } = await import('./iVisualVariablesMixin.gb');
    return await buildDotNetIVisualVariablesMixinGenerated(jsObject, viewId);
}
