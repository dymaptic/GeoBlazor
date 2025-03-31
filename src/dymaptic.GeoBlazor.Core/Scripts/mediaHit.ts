// override generated code in this file


export async function buildJsMediaHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMediaHitGenerated} = await import('./mediaHit.gb');
    return await buildJsMediaHitGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMediaHit(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetMediaHitGenerated} = await import('./mediaHit.gb');
    return await buildDotNetMediaHitGenerated(jsObject, layerId, viewId);
}
