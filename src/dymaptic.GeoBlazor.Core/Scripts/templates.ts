
export async function buildJsTemplates(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplatesGenerated } = await import('./templates.gb');
    return await buildJsTemplatesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplates(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTemplatesGenerated } = await import('./templates.gb');
    return await buildDotNetTemplatesGenerated(jsObject, layerId, viewId);
}
