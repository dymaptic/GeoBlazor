export async function buildJsUIMovePosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUIMovePositionGenerated} = await import('./uIMovePosition.gb');
    return await buildJsUIMovePositionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUIMovePosition(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetUIMovePositionGenerated} = await import('./uIMovePosition.gb');
    return await buildDotNetUIMovePositionGenerated(jsObject, layerId, viewId);
}
