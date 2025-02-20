export async function buildJsFeatureTableCellClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableCellClickEventGenerated} = await import('./featureTableCellClickEvent.gb');
    return await buildJsFeatureTableCellClickEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableCellClickEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableCellClickEventGenerated} = await import('./featureTableCellClickEvent.gb');
    return await buildDotNetFeatureTableCellClickEventGenerated(jsObject);
}
