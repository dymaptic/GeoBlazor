
export async function buildJsIVisualVariablesMixin(dotNetObject: any): Promise<any> {
    let { buildJsIVisualVariablesMixinGenerated } = await import('./iVisualVariablesMixin.gb');
    return buildJsIVisualVariablesMixinGenerated(dotNetObject);
}     

export async function buildDotNetIVisualVariablesMixin(jsObject: any): Promise<any> {
    let { buildDotNetIVisualVariablesMixinGenerated } = await import('./iVisualVariablesMixin.gb');
    return await buildDotNetIVisualVariablesMixinGenerated(jsObject);
}
