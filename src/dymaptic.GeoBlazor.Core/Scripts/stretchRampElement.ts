
export async function buildJsStretchRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStretchRampElementGenerated } = await import('./stretchRampElement.gb');
    return await buildJsStretchRampElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStretchRampElement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetStretchRampElementGenerated } = await import('./stretchRampElement.gb');
    return await buildDotNetStretchRampElementGenerated(jsObject, layerId, viewId);
}
