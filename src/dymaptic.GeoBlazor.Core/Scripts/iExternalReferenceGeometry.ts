
export async function buildJsIExternalReferenceGeometry(dotNetObject: any): Promise<any> {
    let { buildJsIExternalReferenceGeometryGenerated } = await import('./iExternalReferenceGeometry.gb');
    return await buildJsIExternalReferenceGeometryGenerated(dotNetObject);
}     

export async function buildDotNetIExternalReferenceGeometry(jsObject: any): Promise<any> {
    let { buildDotNetIExternalReferenceGeometryGenerated } = await import('./iExternalReferenceGeometry.gb');
    return await buildDotNetIExternalReferenceGeometryGenerated(jsObject);
}
