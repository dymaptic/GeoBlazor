
export async function buildJsSizeRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeRampElementGenerated } = await import('./sizeRampElement.gb');
    return await buildJsSizeRampElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeRampElement(jsObject: any): Promise<any> {
    let { buildDotNetSizeRampElementGenerated } = await import('./sizeRampElement.gb');
    return await buildDotNetSizeRampElementGenerated(jsObject);
}
