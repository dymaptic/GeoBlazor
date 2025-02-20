export async function buildJsSearchViewModelSelectResultEventResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelSelectResultEventResultGenerated} = await import('./searchViewModelSelectResultEventResult.gb');
    return await buildJsSearchViewModelSelectResultEventResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModelSelectResultEventResult(jsObject: any): Promise<any> {
    let {buildDotNetSearchViewModelSelectResultEventResultGenerated} = await import('./searchViewModelSelectResultEventResult.gb');
    return await buildDotNetSearchViewModelSelectResultEventResultGenerated(jsObject);
}
