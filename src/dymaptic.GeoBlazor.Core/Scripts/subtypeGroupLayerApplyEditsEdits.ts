
export async function buildJsSubtypeGroupLayerApplyEditsEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubtypeGroupLayerApplyEditsEditsGenerated } = await import('./subtypeGroupLayerApplyEditsEdits.gb');
    return await buildJsSubtypeGroupLayerApplyEditsEditsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSubtypeGroupLayerApplyEditsEdits(jsObject: any): Promise<any> {
    let { buildDotNetSubtypeGroupLayerApplyEditsEditsGenerated } = await import('./subtypeGroupLayerApplyEditsEdits.gb');
    return await buildDotNetSubtypeGroupLayerApplyEditsEditsGenerated(jsObject);
}
