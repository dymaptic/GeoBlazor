export async function buildJsHitTestResultGround(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHitTestResultGroundGenerated } = await import('./hitTestResultGround.gb');
    return await buildJsHitTestResultGroundGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetHitTestResultGround(jsObject: any): Promise<any> {
    let { buildDotNetHitTestResultGroundGenerated } = await import('./hitTestResultGround.gb');
    return await buildDotNetHitTestResultGroundGenerated(jsObject);
}
