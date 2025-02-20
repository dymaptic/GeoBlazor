export async function buildJsViewshed(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewshedGenerated} = await import('./viewshed.gb');
    return await buildJsViewshedGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewshed(jsObject: any): Promise<any> {
    let {buildDotNetViewshedGenerated} = await import('./viewshed.gb');
    return await buildDotNetViewshedGenerated(jsObject);
}
