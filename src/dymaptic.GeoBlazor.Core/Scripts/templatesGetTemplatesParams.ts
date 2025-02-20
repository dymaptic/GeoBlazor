export async function buildJsTemplatesGetTemplatesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTemplatesGetTemplatesParamsGenerated} = await import('./templatesGetTemplatesParams.gb');
    return await buildJsTemplatesGetTemplatesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTemplatesGetTemplatesParams(jsObject: any): Promise<any> {
    let {buildDotNetTemplatesGetTemplatesParamsGenerated} = await import('./templatesGetTemplatesParams.gb');
    return await buildDotNetTemplatesGetTemplatesParamsGenerated(jsObject);
}
