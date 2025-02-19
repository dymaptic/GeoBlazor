export async function buildJsImageParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageParametersGenerated } = await import('./imageParameters.gb');
    return await buildJsImageParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageParameters(jsObject: any): Promise<any> {
    let { buildDotNetImageParametersGenerated } = await import('./imageParameters.gb');
    return await buildDotNetImageParametersGenerated(jsObject);
}
