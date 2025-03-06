export async function buildJsColorBackground(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorBackgroundGenerated} = await import('./colorBackground.gb');
    return await buildJsColorBackgroundGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorBackground(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetColorBackgroundGenerated} = await import('./colorBackground.gb');
    return await buildDotNetColorBackgroundGenerated(jsObject, layerId, viewId);
}
