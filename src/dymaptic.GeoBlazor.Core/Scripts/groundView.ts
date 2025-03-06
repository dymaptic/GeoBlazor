export async function buildJsGroundView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGroundViewGenerated} = await import('./groundView.gb');
    return await buildJsGroundViewGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGroundView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetGroundViewGenerated} = await import('./groundView.gb');
    return await buildDotNetGroundViewGenerated(jsObject, layerId, viewId);
}
