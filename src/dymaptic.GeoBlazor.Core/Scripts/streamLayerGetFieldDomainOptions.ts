export async function buildJsStreamLayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsStreamLayerGetFieldDomainOptionsGenerated} = await import('./streamLayerGetFieldDomainOptions.gb');
    return await buildJsStreamLayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetStreamLayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let {buildDotNetStreamLayerGetFieldDomainOptionsGenerated} = await import('./streamLayerGetFieldDomainOptions.gb');
    return await buildDotNetStreamLayerGetFieldDomainOptionsGenerated(jsObject);
}
