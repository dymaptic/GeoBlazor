// override generated code in this file

export async function buildJsActionButton(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsActionButtonGenerated} = await import('./actionButton.gb');
    return await buildJsActionButtonGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetActionButton(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetActionButtonGenerated} = await import('./actionButton.gb');
    return await buildDotNetActionButtonGenerated(jsObject, layerId, viewId);
}
