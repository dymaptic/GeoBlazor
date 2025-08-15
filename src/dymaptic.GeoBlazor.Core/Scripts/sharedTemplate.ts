
export async function buildJsSharedTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSharedTemplateGenerated } = await import('./sharedTemplate.gb');
    return await buildJsSharedTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSharedTemplate(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSharedTemplateGenerated } = await import('./sharedTemplate.gb');
    return await buildDotNetSharedTemplateGenerated(jsObject, viewId);
}
