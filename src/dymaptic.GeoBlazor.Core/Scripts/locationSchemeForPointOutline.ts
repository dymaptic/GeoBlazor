export async function buildJsLocationSchemeForPointOutline(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationSchemeForPointOutlineGenerated} = await import('./locationSchemeForPointOutline.gb');
    return await buildJsLocationSchemeForPointOutlineGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocationSchemeForPointOutline(jsObject: any): Promise<any> {
    let {buildDotNetLocationSchemeForPointOutlineGenerated} = await import('./locationSchemeForPointOutline.gb');
    return await buildDotNetLocationSchemeForPointOutlineGenerated(jsObject);
}
