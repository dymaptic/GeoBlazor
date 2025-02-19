export async function buildJsTemplateOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateOptionsGenerated } = await import('./templateOptions.gb');
    return await buildJsTemplateOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTemplateOptions(jsObject: any): Promise<any> {
    let { buildDotNetTemplateOptionsGenerated } = await import('./templateOptions.gb');
    return await buildDotNetTemplateOptionsGenerated(jsObject);
}
