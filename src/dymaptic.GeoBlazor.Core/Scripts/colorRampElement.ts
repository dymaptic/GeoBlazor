export async function buildJsColorRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorRampElementGenerated} = await import('./colorRampElement.gb');
    return await buildJsColorRampElementGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorRampElement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetColorRampElementGenerated} = await import('./colorRampElement.gb');
    return await buildDotNetColorRampElementGenerated(jsObject, layerId, viewId);
}
