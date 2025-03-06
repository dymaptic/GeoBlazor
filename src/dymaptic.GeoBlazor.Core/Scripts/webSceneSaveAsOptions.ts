export async function buildJsWebSceneSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWebSceneSaveAsOptionsGenerated} = await import('./webSceneSaveAsOptions.gb');
    return await buildJsWebSceneSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWebSceneSaveAsOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetWebSceneSaveAsOptionsGenerated} = await import('./webSceneSaveAsOptions.gb');
    return await buildDotNetWebSceneSaveAsOptionsGenerated(jsObject, layerId, viewId);
}
