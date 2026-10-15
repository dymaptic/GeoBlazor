
export async function buildJsSketchTooltipOptions(dotNetObject: any): Promise<any> {
    let { buildJsSketchTooltipOptionsGenerated } = await import('./sketchTooltipOptions.gb');
    return await buildJsSketchTooltipOptionsGenerated(dotNetObject);
}     

export async function buildDotNetSketchTooltipOptions(jsObject: any): Promise<any> {
    let { buildDotNetSketchTooltipOptionsGenerated } = await import('./sketchTooltipOptions.gb');
    return await buildDotNetSketchTooltipOptionsGenerated(jsObject);
}
