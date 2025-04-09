
export async function buildJsUnivariateColorSizeRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnivariateColorSizeRampElementGenerated } = await import('./univariateColorSizeRampElement.gb');
    return await buildJsUnivariateColorSizeRampElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnivariateColorSizeRampElement(jsObject: any): Promise<any> {
    let { buildDotNetUnivariateColorSizeRampElementGenerated } = await import('./univariateColorSizeRampElement.gb');
    return await buildDotNetUnivariateColorSizeRampElementGenerated(jsObject);
}
