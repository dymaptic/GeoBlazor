
export async function buildJsFeatureTableViewModelCellDblclickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTableViewModelCellDblclickEventGenerated } = await import('./featureTableViewModelCellDblclickEvent.gb');
    return await buildJsFeatureTableViewModelCellDblclickEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTableViewModelCellDblclickEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTableViewModelCellDblclickEventGenerated } = await import('./featureTableViewModelCellDblclickEvent.gb');
    return await buildDotNetFeatureTableViewModelCellDblclickEventGenerated(jsObject, layerId, viewId);
}
