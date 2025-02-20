export async function buildJsColumnTemplateBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColumnTemplateBaseGenerated} = await import('./columnTemplateBase.gb');
    return await buildJsColumnTemplateBaseGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColumnTemplateBase(jsObject: any): Promise<any> {
    let {buildDotNetColumnTemplateBaseGenerated} = await import('./columnTemplateBase.gb');
    return await buildDotNetColumnTemplateBaseGenerated(jsObject);
}
