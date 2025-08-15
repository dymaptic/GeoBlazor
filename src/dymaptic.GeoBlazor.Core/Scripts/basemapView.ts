export async function buildJsBasemapView(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsBasemapViewGenerated} = await import('./basemapView.gb');
    return await buildJsBasemapViewGenerated(dotNetObject, viewId);
}

export async function buildDotNetBasemapView(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetBasemapViewGenerated} = await import('./basemapView.gb');
    return await buildDotNetBasemapViewGenerated(jsObject, viewId);
}
