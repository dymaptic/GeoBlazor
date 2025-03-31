export async function buildJsPosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPositionGenerated} = await import('./position.gb');
    return await buildJsPositionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPosition(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPositionGenerated} = await import('./position.gb');
    return await buildDotNetPositionGenerated(jsObject, layerId, viewId);
}
