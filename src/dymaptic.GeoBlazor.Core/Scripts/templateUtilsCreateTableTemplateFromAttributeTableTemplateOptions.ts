
export async function buildJsTemplateUtilsCreateTableTemplateFromAttributeTableTemplateOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateUtilsCreateTableTemplateFromAttributeTableTemplateOptionsGenerated } = await import('./templateUtilsCreateTableTemplateFromAttributeTableTemplateOptions.gb');
    return await buildJsTemplateUtilsCreateTableTemplateFromAttributeTableTemplateOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplateUtilsCreateTableTemplateFromAttributeTableTemplateOptions(jsObject: any): Promise<any> {
    let { buildDotNetTemplateUtilsCreateTableTemplateFromAttributeTableTemplateOptionsGenerated } = await import('./templateUtilsCreateTableTemplateFromAttributeTableTemplateOptions.gb');
    return await buildDotNetTemplateUtilsCreateTableTemplateFromAttributeTableTemplateOptionsGenerated(jsObject);
}
