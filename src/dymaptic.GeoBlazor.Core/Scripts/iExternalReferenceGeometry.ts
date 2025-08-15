
export async function buildJsIExternalReferenceGeometry(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIExternalReferenceGeometryGenerated } = await import('./iExternalReferenceGeometry.gb');
    return await buildJsIExternalReferenceGeometryGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIExternalReferenceGeometry(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIExternalReferenceGeometryGenerated } = await import('./iExternalReferenceGeometry.gb');
    return await buildDotNetIExternalReferenceGeometryGenerated(jsObject, viewId);
}
