export async function buildJsPrintTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPrintTemplateGenerated} = await import('./printTemplate.gb');
    return await buildJsPrintTemplateGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPrintTemplate(jsObject: any): Promise<any> {
    let {buildDotNetPrintTemplateGenerated} = await import('./printTemplate.gb');
    return await buildDotNetPrintTemplateGenerated(jsObject);
}
