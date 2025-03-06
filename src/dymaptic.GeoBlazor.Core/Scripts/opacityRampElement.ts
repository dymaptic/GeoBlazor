
export async function buildJsOpacityRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacityRampElementGenerated } = await import('./opacityRampElement.gb');
    return await buildJsOpacityRampElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacityRampElement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityRampElementGenerated } = await import('./opacityRampElement.gb');
    return await buildDotNetOpacityRampElementGenerated(jsObject, layerId, viewId);
}
