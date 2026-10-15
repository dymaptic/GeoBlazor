// override generated code in this file

export async function buildJsTemplateItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateItemGenerated } = await import('./templateItem.gb');
    return await buildJsTemplateItemGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplateItem(jsObject: any): Promise<any> {
    let { buildDotNetTemplateItemGenerated } = await import('./templateItem.gb');
    return await buildDotNetTemplateItemGenerated(jsObject);
}

