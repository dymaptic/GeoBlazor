export async function buildJsFeatureTableCellKeydownEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTableCellKeydownEventGenerated} = await import('./featureTableCellKeydownEvent.gb');
    return await buildJsFeatureTableCellKeydownEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTableCellKeydownEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTableCellKeydownEventGenerated} = await import('./featureTableCellKeydownEvent.gb');
    return await buildDotNetFeatureTableCellKeydownEventGenerated(jsObject);
}
