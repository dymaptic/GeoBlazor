
export async function buildJsDomainProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDomainPropertiesGenerated } = await import('./domainProperties.gb');
    return await buildJsDomainPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDomainProperties(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetDomainPropertiesGenerated } = await import('./domainProperties.gb');
    return await buildDotNetDomainPropertiesGenerated(jsObject, viewId);
}
