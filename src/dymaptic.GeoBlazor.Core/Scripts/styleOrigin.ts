// override generated code in this file

export async function buildJsStyleOrigin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsStyleOriginGenerated} = await import('./styleOrigin.gb');
    return await buildJsStyleOriginGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetStyleOrigin(jsObject: any): Promise<any> {
    let {buildDotNetStyleOriginGenerated} = await import('./styleOrigin.gb');
    return await buildDotNetStyleOriginGenerated(jsObject);
}
