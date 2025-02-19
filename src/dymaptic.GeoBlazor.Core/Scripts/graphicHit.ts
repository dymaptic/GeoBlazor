export async function buildJsGraphicHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicHitGenerated } = await import('./graphicHit.gb');
    return await buildJsGraphicHitGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetGraphicHit(jsObject: any): Promise<any> {
    let { buildDotNetGraphicHitGenerated } = await import('./graphicHit.gb');
    return await buildDotNetGraphicHitGenerated(jsObject);
}
