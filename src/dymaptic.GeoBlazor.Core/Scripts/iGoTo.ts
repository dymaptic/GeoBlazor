
export async function buildJsIGoTo(dotNetObject: any): Promise<any> {
    let { buildJsIGoToGenerated } = await import('./iGoTo.gb');
    return buildJsIGoToGenerated(dotNetObject);
}     

export async function buildDotNetIGoTo(jsObject: any): Promise<any> {
    let { buildDotNetIGoToGenerated } = await import('./iGoTo.gb');
    return await buildDotNetIGoToGenerated(jsObject);
}
