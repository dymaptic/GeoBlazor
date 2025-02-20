// override generated code in this file


export async function buildJsImageryLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerSaveAsOptionsGenerated} = await import('./imageryLayerSaveAsOptions.gb');
    return await buildJsImageryLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageryLayerSaveAsOptions(jsObject: any): Promise<any> {
    let {buildDotNetImageryLayerSaveAsOptionsGenerated} = await import('./imageryLayerSaveAsOptions.gb');
    return await buildDotNetImageryLayerSaveAsOptionsGenerated(jsObject);
}
