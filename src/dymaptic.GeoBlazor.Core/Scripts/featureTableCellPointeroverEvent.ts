export async function buildJsFeatureTableCellPointeroverEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableCellPointeroverEventGenerated} = await import('./featureTableCellPointeroverEvent.gb');
    return await buildJsFeatureTableCellPointeroverEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableCellPointeroverEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableCellPointeroverEventGenerated} = await import('./featureTableCellPointeroverEvent.gb');
    return await buildDotNetFeatureTableCellPointeroverEventGenerated(jsObject);
}
