
export async function buildJsWMTSStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWMTSStyleGenerated } = await import('./wMTSStyle.gb');
    return await buildJsWMTSStyleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWMTSStyle(jsObject: any): Promise<any> {
    let { buildDotNetWMTSStyleGenerated } = await import('./wMTSStyle.gb');
    return await buildDotNetWMTSStyleGenerated(jsObject);
}
