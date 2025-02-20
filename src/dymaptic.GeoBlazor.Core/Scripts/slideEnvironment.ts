export async function buildJsSlideEnvironment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSlideEnvironmentGenerated} = await import('./slideEnvironment.gb');
    return await buildJsSlideEnvironmentGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSlideEnvironment(jsObject: any): Promise<any> {
    let {buildDotNetSlideEnvironmentGenerated} = await import('./slideEnvironment.gb');
    return await buildDotNetSlideEnvironmentGenerated(jsObject);
}
