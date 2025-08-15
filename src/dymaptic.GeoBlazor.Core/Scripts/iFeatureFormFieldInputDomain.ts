
export async function buildJsIFeatureFormFieldInputDomain(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureFormFieldInputDomainGenerated } = await import('./iFeatureFormFieldInputDomain.gb');
    return await buildJsIFeatureFormFieldInputDomainGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureFormFieldInputDomain(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureFormFieldInputDomainGenerated } = await import('./iFeatureFormFieldInputDomain.gb');
    return await buildDotNetIFeatureFormFieldInputDomainGenerated(jsObject, viewId);
}
