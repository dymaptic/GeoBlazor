// override generated code in this file


export async function buildJsFetchResource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFetchResourceGenerated} = await import('./fetchResource.gb');
    return await buildJsFetchResourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFetchResource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetFetchResourceGenerated} = await import('./fetchResource.gb');
    return await buildDotNetFetchResourceGenerated(jsObject, layerId, viewId);
}
