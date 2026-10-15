// override generated code in this file


export async function buildJsImageryLayerSaveAsOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsImageryLayerSaveAsOptionsGenerated} = await import('./imageryLayerSaveAsOptions.gb');
    return await buildJsImageryLayerSaveAsOptionsGenerated(dotNetObject, viewId);
}

export async function buildDotNetImageryLayerSaveAsOptions(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetImageryLayerSaveAsOptionsGenerated} = await import('./imageryLayerSaveAsOptions.gb');
    return await buildDotNetImageryLayerSaveAsOptionsGenerated(jsObject, viewId);
}
