
export async function buildJsColumnTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColumnTemplateGenerated } = await import('./columnTemplate.gb');
    return await buildJsColumnTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColumnTemplate(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetColumnTemplateGenerated } = await import('./columnTemplate.gb');
    return await buildDotNetColumnTemplateGenerated(jsObject, layerId, viewId);
}
