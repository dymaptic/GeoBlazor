
export async function buildJsTemplateUtilsCreateDefaultAttributeTableTemplateFromLayerOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateUtilsCreateDefaultAttributeTableTemplateFromLayerOptionsGenerated } = await import('./templateUtilsCreateDefaultAttributeTableTemplateFromLayerOptions.gb');
    return await buildJsTemplateUtilsCreateDefaultAttributeTableTemplateFromLayerOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplateUtilsCreateDefaultAttributeTableTemplateFromLayerOptions(jsObject: any): Promise<any> {
    let { buildDotNetTemplateUtilsCreateDefaultAttributeTableTemplateFromLayerOptionsGenerated } = await import('./templateUtilsCreateDefaultAttributeTableTemplateFromLayerOptions.gb');
    return await buildDotNetTemplateUtilsCreateDefaultAttributeTableTemplateFromLayerOptionsGenerated(jsObject);
}
