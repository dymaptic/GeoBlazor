
export async function buildJsVisualVariableLegendOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVisualVariableLegendOptionsGenerated } = await import('./visualVariableLegendOptions.gb');
    return await buildJsVisualVariableLegendOptionsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVisualVariableLegendOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVisualVariableLegendOptionsGenerated } = await import('./visualVariableLegendOptions.gb');
    return await buildDotNetVisualVariableLegendOptionsGenerated(jsObject, viewId);
}
