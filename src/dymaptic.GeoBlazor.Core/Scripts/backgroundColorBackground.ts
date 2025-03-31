export async function buildJsBackgroundColorBackground(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBackgroundColorBackgroundGenerated} = await import('./backgroundColorBackground.gb');
    return await buildJsBackgroundColorBackgroundGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBackgroundColorBackground(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBackgroundColorBackgroundGenerated} = await import('./backgroundColorBackground.gb');
    return await buildDotNetBackgroundColorBackgroundGenerated(jsObject, layerId, viewId);
}
