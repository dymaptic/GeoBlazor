export async function buildJsPCClassRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPCClassRendererResultGenerated} = await import('./pCClassRendererResult.gb');
    return await buildJsPCClassRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPCClassRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetPCClassRendererResultGenerated} = await import('./pCClassRendererResult.gb');
    return await buildDotNetPCClassRendererResultGenerated(jsObject);
}
