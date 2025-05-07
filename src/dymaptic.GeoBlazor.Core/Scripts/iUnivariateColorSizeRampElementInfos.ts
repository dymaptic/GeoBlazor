
export async function buildJsIUnivariateColorSizeRampElementInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIUnivariateColorSizeRampElementInfosGenerated } = await import('./iUnivariateColorSizeRampElementInfos.gb');
    return await buildJsIUnivariateColorSizeRampElementInfosGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIUnivariateColorSizeRampElementInfos(jsObject: any): Promise<any> {
    let { buildDotNetIUnivariateColorSizeRampElementInfosGenerated } = await import('./iUnivariateColorSizeRampElementInfos.gb');
    return await buildDotNetIUnivariateColorSizeRampElementInfosGenerated(jsObject);
}
