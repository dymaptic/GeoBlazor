
export async function buildJsSketchTooltipOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchTooltipOptionsGenerated } = await import('./sketchTooltipOptions.gb');
    return await buildJsSketchTooltipOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchTooltipOptions(jsObject: any): Promise<any> {
    let { buildDotNetSketchTooltipOptionsGenerated } = await import('./sketchTooltipOptions.gb');
    return await buildDotNetSketchTooltipOptionsGenerated(jsObject);
}
