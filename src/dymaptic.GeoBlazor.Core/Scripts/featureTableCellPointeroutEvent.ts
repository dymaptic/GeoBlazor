export async function buildJsFeatureTableCellPointeroutEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableCellPointeroutEventGenerated} = await import('./featureTableCellPointeroutEvent.gb');
    return await buildJsFeatureTableCellPointeroutEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableCellPointeroutEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableCellPointeroutEventGenerated} = await import('./featureTableCellPointeroutEvent.gb');
    return await buildDotNetFeatureTableCellPointeroutEventGenerated(jsObject);
}
