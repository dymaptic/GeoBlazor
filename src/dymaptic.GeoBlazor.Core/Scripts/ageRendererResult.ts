export async function buildJsAgeRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAgeRendererResultGenerated} = await import('./ageRendererResult.gb');
    return await buildJsAgeRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAgeRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetAgeRendererResultGenerated} = await import('./ageRendererResult.gb');
    return await buildDotNetAgeRendererResultGenerated(jsObject);
}
