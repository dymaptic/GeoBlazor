
export async function buildJsFieldColumnTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldColumnTemplateGenerated } = await import('./fieldColumnTemplate.gb');
    return await buildJsFieldColumnTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldColumnTemplate(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFieldColumnTemplateGenerated } = await import('./fieldColumnTemplate.gb');
    return await buildDotNetFieldColumnTemplateGenerated(jsObject, layerId, viewId);
}
