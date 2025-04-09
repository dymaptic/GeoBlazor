
export async function buildJsComponentsReactiveUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsComponentsReactiveUtilsGenerated } = await import('./componentsReactiveUtils.gb');
    return await buildJsComponentsReactiveUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetComponentsReactiveUtils(jsObject: any): Promise<any> {
    let { buildDotNetComponentsReactiveUtilsGenerated } = await import('./componentsReactiveUtils.gb');
    return await buildDotNetComponentsReactiveUtilsGenerated(jsObject);
}
