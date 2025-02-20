export async function buildJsMediaLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMediaLayerViewGenerated} = await import('./mediaLayerView.gb');
    return await buildJsMediaLayerViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMediaLayerView(jsObject: any): Promise<any> {
    let {buildDotNetMediaLayerViewGenerated} = await import('./mediaLayerView.gb');
    return await buildDotNetMediaLayerViewGenerated(jsObject);
}
