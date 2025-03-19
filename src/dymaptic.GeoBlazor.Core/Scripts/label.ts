export async function buildJsLabel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLabelGenerated} = await import('./label.gb');
    return await buildJsLabelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLabel(jsObject: any): Promise<any> {
    let {buildDotNetLabelGenerated} = await import('./label.gb');
    return await buildDotNetLabelGenerated(jsObject);
}
