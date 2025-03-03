
export async function buildJsServiceDescription(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceDescriptionGenerated } = await import('./serviceDescription.gb');
    return await buildJsServiceDescriptionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceDescription(jsObject: any): Promise<any> {
    let { buildDotNetServiceDescriptionGenerated } = await import('./serviceDescription.gb');
    return await buildDotNetServiceDescriptionGenerated(jsObject);
}
