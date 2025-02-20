export async function buildJsPrintTemplateLayoutOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPrintTemplateLayoutOptionsGenerated} = await import('./printTemplateLayoutOptions.gb');
    return await buildJsPrintTemplateLayoutOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPrintTemplateLayoutOptions(jsObject: any): Promise<any> {
    let {buildDotNetPrintTemplateLayoutOptionsGenerated} = await import('./printTemplateLayoutOptions.gb');
    return await buildDotNetPrintTemplateLayoutOptionsGenerated(jsObject);
}
