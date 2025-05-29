
export async function buildJsSketchUtilsSetCustomToolsCustomActionOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchUtilsSetCustomToolsCustomActionOptionsGenerated } = await import('./sketchUtilsSetCustomToolsCustomActionOptions.gb');
    return await buildJsSketchUtilsSetCustomToolsCustomActionOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchUtilsSetCustomToolsCustomActionOptions(jsObject: any): Promise<any> {
    let { buildDotNetSketchUtilsSetCustomToolsCustomActionOptionsGenerated } = await import('./sketchUtilsSetCustomToolsCustomActionOptions.gb');
    return await buildDotNetSketchUtilsSetCustomToolsCustomActionOptionsGenerated(jsObject);
}
