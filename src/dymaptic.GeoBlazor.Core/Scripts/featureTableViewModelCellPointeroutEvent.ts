export async function buildJsFeatureTableViewModelCellPointeroutEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableViewModelCellPointeroutEventGenerated} = await import('./featureTableViewModelCellPointeroutEvent.gb');
    return await buildJsFeatureTableViewModelCellPointeroutEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableViewModelCellPointeroutEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableViewModelCellPointeroutEventGenerated} = await import('./featureTableViewModelCellPointeroutEvent.gb');
    return await buildDotNetFeatureTableViewModelCellPointeroutEventGenerated(jsObject);
}
