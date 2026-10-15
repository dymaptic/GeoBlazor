
export async function buildJsAssociation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAssociationGenerated } = await import('./association.gb');
    return await buildJsAssociationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAssociation(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAssociationGenerated } = await import('./association.gb');
    return await buildDotNetAssociationGenerated(jsObject, viewId);
}
