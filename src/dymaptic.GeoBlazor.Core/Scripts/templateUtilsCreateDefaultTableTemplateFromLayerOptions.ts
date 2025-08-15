
export async function buildJsTemplateUtilsCreateDefaultTableTemplateFromLayerOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateUtilsCreateDefaultTableTemplateFromLayerOptionsGenerated } = await import('./templateUtilsCreateDefaultTableTemplateFromLayerOptions.gb');
    return await buildJsTemplateUtilsCreateDefaultTableTemplateFromLayerOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplateUtilsCreateDefaultTableTemplateFromLayerOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTemplateUtilsCreateDefaultTableTemplateFromLayerOptionsGenerated } = await import('./templateUtilsCreateDefaultTableTemplateFromLayerOptions.gb');
    return await buildDotNetTemplateUtilsCreateDefaultTableTemplateFromLayerOptionsGenerated(jsObject, viewId);
}
