
export async function buildJsInheritedDomain(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsInheritedDomainGenerated } = await import('./inheritedDomain.gb');
    return await buildJsInheritedDomainGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetInheritedDomain(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetInheritedDomainGenerated } = await import('./inheritedDomain.gb');
    return await buildDotNetInheritedDomainGenerated(jsObject, layerId, viewId);
}
