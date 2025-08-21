
export async function buildJsOpacityRampElement(dotNetObject: any): Promise<any> {
    let { buildJsOpacityRampElementGenerated } = await import('./opacityRampElement.gb');
    return await buildJsOpacityRampElementGenerated(dotNetObject);
}     

export async function buildDotNetOpacityRampElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityRampElementGenerated } = await import('./opacityRampElement.gb');
    return await buildDotNetOpacityRampElementGenerated(jsObject, viewId);
}
