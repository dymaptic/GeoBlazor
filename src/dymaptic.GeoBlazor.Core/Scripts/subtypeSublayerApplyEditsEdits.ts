
export async function buildJsSubtypeSublayerApplyEditsEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubtypeSublayerApplyEditsEditsGenerated } = await import('./subtypeSublayerApplyEditsEdits.gb');
    return await buildJsSubtypeSublayerApplyEditsEditsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSubtypeSublayerApplyEditsEdits(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSubtypeSublayerApplyEditsEditsGenerated } = await import('./subtypeSublayerApplyEditsEdits.gb');
    return await buildDotNetSubtypeSublayerApplyEditsEditsGenerated(jsObject, layerId, viewId);
}
