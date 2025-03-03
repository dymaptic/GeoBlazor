
export async function buildJsExternalReferencePoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExternalReferencePointGenerated } = await import('./externalReferencePoint.gb');
    return await buildJsExternalReferencePointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExternalReferencePoint(jsObject: any): Promise<any> {
    let { buildDotNetExternalReferencePointGenerated } = await import('./externalReferencePoint.gb');
    return await buildDotNetExternalReferencePointGenerated(jsObject);
}
