export async function buildJsFeatureTableViewModelCellKeydownEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTableViewModelCellKeydownEventGenerated } = await import('./featureTableViewModelCellKeydownEvent.gb');
    return await buildJsFeatureTableViewModelCellKeydownEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureTableViewModelCellKeydownEvent(jsObject: any): Promise<any> {
    let { buildDotNetFeatureTableViewModelCellKeydownEventGenerated } = await import('./featureTableViewModelCellKeydownEvent.gb');
    return await buildDotNetFeatureTableViewModelCellKeydownEventGenerated(jsObject);
}
