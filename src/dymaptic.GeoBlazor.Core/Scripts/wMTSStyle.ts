
export async function buildJsWMTSStyle(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsWMTSStyleGenerated } = await import('./wMTSStyle.gb');
    return await buildJsWMTSStyleGenerated(dotNetObject, viewId);
}     

export async function buildDotNetWMTSStyle(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWMTSStyleGenerated } = await import('./wMTSStyle.gb');
    return await buildDotNetWMTSStyleGenerated(jsObject, viewId);
}
