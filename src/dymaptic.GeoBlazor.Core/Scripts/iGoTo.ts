
export async function buildJsIGoTo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIGoToGenerated } = await import('./iGoTo.gb');
    return await buildJsIGoToGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIGoTo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIGoToGenerated } = await import('./iGoTo.gb');
    return await buildDotNetIGoToGenerated(jsObject, viewId);
}
