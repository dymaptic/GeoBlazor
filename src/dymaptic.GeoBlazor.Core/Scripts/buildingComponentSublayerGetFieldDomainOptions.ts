
export async function buildJsBuildingComponentSublayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingComponentSublayerGetFieldDomainOptionsGenerated } = await import('./buildingComponentSublayerGetFieldDomainOptions.gb');
    return await buildJsBuildingComponentSublayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingComponentSublayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let { buildDotNetBuildingComponentSublayerGetFieldDomainOptionsGenerated } = await import('./buildingComponentSublayerGetFieldDomainOptions.gb');
    return await buildDotNetBuildingComponentSublayerGetFieldDomainOptionsGenerated(jsObject);
}
