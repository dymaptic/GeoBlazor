
export async function buildJsDefaultsFromMapRequiredComponents(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDefaultsFromMapRequiredComponentsGenerated } = await import('./defaultsFromMapRequiredComponents.gb');
    return await buildJsDefaultsFromMapRequiredComponentsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDefaultsFromMapRequiredComponents(jsObject: any): Promise<any> {
    let { buildDotNetDefaultsFromMapRequiredComponentsGenerated } = await import('./defaultsFromMapRequiredComponents.gb');
    return await buildDotNetDefaultsFromMapRequiredComponentsGenerated(jsObject);
}
