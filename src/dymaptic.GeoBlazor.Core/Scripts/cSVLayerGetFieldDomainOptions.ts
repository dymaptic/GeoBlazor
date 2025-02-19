// override generated code in this file
export async function buildJsCSVLayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerGetFieldDomainOptionsGenerated } = await import('./cSVLayerGetFieldDomainOptions.gb');
    return await buildJsCSVLayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCSVLayerGetFieldDomainOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerGetFieldDomainOptionsGenerated } = await import('./cSVLayerGetFieldDomainOptions.gb');
    return await buildDotNetCSVLayerGetFieldDomainOptionsGenerated(jsObject, layerId, viewId);
}
