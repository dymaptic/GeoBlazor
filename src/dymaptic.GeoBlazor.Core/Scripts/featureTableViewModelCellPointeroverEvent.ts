export async function buildJsFeatureTableViewModelCellPointeroverEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableViewModelCellPointeroverEventGenerated} = await import('./featureTableViewModelCellPointeroverEvent.gb');
    return await buildJsFeatureTableViewModelCellPointeroverEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableViewModelCellPointeroverEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableViewModelCellPointeroverEventGenerated} = await import('./featureTableViewModelCellPointeroverEvent.gb');
    return await buildDotNetFeatureTableViewModelCellPointeroverEventGenerated(jsObject);
}
