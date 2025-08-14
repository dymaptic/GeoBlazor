
export async function buildJsIFeatureFormFieldInputDomain(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureFormFieldInputDomainGenerated } = await import('./iFeatureFormFieldInputDomain.gb');
    return await buildJsIFeatureFormFieldInputDomainGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureFormFieldInputDomain(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureFormFieldInputDomainGenerated } = await import('./iFeatureFormFieldInputDomain.gb');
    return await buildDotNetIFeatureFormFieldInputDomainGenerated(jsObject);
}
