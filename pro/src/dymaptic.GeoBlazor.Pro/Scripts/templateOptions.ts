
export async function buildJsTemplateOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateOptionsGenerated } = await import('./templateOptions.gb');
    let jsTemplateOptions = await buildJsTemplateOptionsGenerated(dotNetObject, layerId, viewId);
    
    jsTemplateOptions.format = dotNetObject.format;
    
    return jsTemplateOptions;
}     

export async function buildDotNetTemplateOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTemplateOptionsGenerated } = await import('./templateOptions.gb');
    let dnTemplateOptions = await buildDotNetTemplateOptionsGenerated(jsObject, layerId, viewId);
    dnTemplateOptions.format = jsObject.format;
    return dnTemplateOptions;
}
