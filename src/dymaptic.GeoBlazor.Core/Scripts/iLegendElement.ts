
export async function buildJsILegendElement(dotNetObject: any): Promise<any> {
    let { buildJsILegendElementGenerated } = await import('./iLegendElement.gb');
    return await buildJsILegendElementGenerated(dotNetObject);
}     

export async function buildDotNetILegendElement(jsObject: any): Promise<any> {
    let { buildDotNetILegendElementGenerated } = await import('./iLegendElement.gb');
    return await buildDotNetILegendElementGenerated(jsObject);
}
