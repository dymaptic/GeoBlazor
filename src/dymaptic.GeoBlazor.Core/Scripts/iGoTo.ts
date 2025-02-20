
export async function buildJsIGoTo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIGoToGenerated } = await import('./iGoTo.gb');
    return await buildJsIGoToGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIGoTo(jsObject: any): Promise<any> {
    let { buildDotNetIGoToGenerated } = await import('./iGoTo.gb');
    return await buildDotNetIGoToGenerated(jsObject);
}
