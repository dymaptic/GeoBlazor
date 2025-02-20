export async function buildJsFeatureTableViewModelCellClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableViewModelCellClickEventGenerated} = await import('./featureTableViewModelCellClickEvent.gb');
    return await buildJsFeatureTableViewModelCellClickEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableViewModelCellClickEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableViewModelCellClickEventGenerated} = await import('./featureTableViewModelCellClickEvent.gb');
    return await buildDotNetFeatureTableViewModelCellClickEventGenerated(jsObject);
}
