
export async function buildJsGroupColumnTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupColumnTemplateGenerated } = await import('./groupColumnTemplate.gb');
    return await buildJsGroupColumnTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupColumnTemplate(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGroupColumnTemplateGenerated } = await import('./groupColumnTemplate.gb');
    return await buildDotNetGroupColumnTemplateGenerated(jsObject, layerId, viewId);
}
