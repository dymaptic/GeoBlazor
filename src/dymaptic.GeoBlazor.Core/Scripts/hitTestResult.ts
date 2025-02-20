export async function buildJsHitTestResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHitTestResultGenerated} = await import('./hitTestResult.gb');
    return await buildJsHitTestResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHitTestResult(jsObject: any): Promise<any> {
    let {buildDotNetHitTestResultGenerated} = await import('./hitTestResult.gb');
    return await buildDotNetHitTestResultGenerated(jsObject);
}
