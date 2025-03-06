export async function buildJsUIAddPosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUIAddPositionGenerated} = await import('./uIAddPosition.gb');
    return await buildJsUIAddPositionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUIAddPosition(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetUIAddPositionGenerated} = await import('./uIAddPosition.gb');
    return await buildDotNetUIAddPositionGenerated(jsObject, layerId, viewId);
}
