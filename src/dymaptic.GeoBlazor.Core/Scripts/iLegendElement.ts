
export async function buildJsILegendElement(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsILegendElementGenerated } = await import('./iLegendElement.gb');
    return await buildJsILegendElementGenerated(dotNetObject, viewId);
}     

export async function buildDotNetILegendElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetILegendElementGenerated } = await import('./iLegendElement.gb');
    return await buildDotNetILegendElementGenerated(jsObject, viewId);
}
