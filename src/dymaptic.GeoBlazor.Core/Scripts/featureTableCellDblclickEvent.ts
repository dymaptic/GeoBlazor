
export async function buildJsFeatureTableCellDblclickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTableCellDblclickEventGenerated } = await import('./featureTableCellDblclickEvent.gb');
    return await buildJsFeatureTableCellDblclickEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTableCellDblclickEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTableCellDblclickEventGenerated } = await import('./featureTableCellDblclickEvent.gb');
    return await buildDotNetFeatureTableCellDblclickEventGenerated(jsObject, layerId, viewId);
}
