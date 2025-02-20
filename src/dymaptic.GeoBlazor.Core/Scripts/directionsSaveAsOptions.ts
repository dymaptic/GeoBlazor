export async function buildJsDirectionsSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectionsSaveAsOptionsGenerated} = await import('./directionsSaveAsOptions.gb');
    return await buildJsDirectionsSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectionsSaveAsOptions(jsObject: any): Promise<any> {
    let {buildDotNetDirectionsSaveAsOptionsGenerated} = await import('./directionsSaveAsOptions.gb');
    return await buildDotNetDirectionsSaveAsOptionsGenerated(jsObject);
}
