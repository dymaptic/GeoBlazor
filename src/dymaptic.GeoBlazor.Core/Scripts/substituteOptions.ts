
export async function buildJsSubstituteOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubstituteOptionsGenerated } = await import('./substituteOptions.gb');
    return await buildJsSubstituteOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSubstituteOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSubstituteOptionsGenerated } = await import('./substituteOptions.gb');
    return await buildDotNetSubstituteOptionsGenerated(jsObject, layerId, viewId);
}
