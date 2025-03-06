// override generated code in this file

export async function buildJsActionToggle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsActionToggleGenerated} = await import('./actionToggle.gb');
    return await buildJsActionToggleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetActionToggle(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetActionToggleGenerated} = await import('./actionToggle.gb');
    return await buildDotNetActionToggleGenerated(jsObject, layerId, viewId);
}
