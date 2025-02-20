// override generated code in this file


export async function buildJsSublayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSublayerGetFieldDomainOptionsGenerated} = await import('./sublayerGetFieldDomainOptions.gb');
    return await buildJsSublayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSublayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let {buildDotNetSublayerGetFieldDomainOptionsGenerated} = await import('./sublayerGetFieldDomainOptions.gb');
    return await buildDotNetSublayerGetFieldDomainOptionsGenerated(jsObject);
}
