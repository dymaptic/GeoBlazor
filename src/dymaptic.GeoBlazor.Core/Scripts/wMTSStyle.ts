
export async function buildJsWMTSStyle(dotNetObject: any): Promise<any> {
    let { buildJsWMTSStyleGenerated } = await import('./wMTSStyle.gb');
    return await buildJsWMTSStyleGenerated(dotNetObject);
}     

export async function buildDotNetWMTSStyle(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWMTSStyleGenerated } = await import('./wMTSStyle.gb');
    return await buildDotNetWMTSStyleGenerated(jsObject, viewId);
}
