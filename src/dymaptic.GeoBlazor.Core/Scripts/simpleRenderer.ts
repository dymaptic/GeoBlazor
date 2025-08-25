// override generated code in this file

export async function buildJsSimpleRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSimpleRendererGenerated} = await import('./simpleRenderer.gb');
    return await buildJsSimpleRendererGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSimpleRenderer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetSimpleRendererGenerated} = await import('./simpleRenderer.gb');
    return await buildDotNetSimpleRendererGenerated(jsObject, viewId);
}
