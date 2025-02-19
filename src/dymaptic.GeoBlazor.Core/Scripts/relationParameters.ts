export async function buildJsRelationParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationParametersGenerated } = await import('./relationParameters.gb');
    return await buildJsRelationParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelationParameters(jsObject: any): Promise<any> {
    let { buildDotNetRelationParametersGenerated } = await import('./relationParameters.gb');
    return await buildDotNetRelationParametersGenerated(jsObject);
}
