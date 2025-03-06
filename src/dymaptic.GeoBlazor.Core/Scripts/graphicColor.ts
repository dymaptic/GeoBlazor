
export async function buildJsGraphicColor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicColorGenerated } = await import('./graphicColor.gb');
    return await buildJsGraphicColorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphicColor(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGraphicColorGenerated } = await import('./graphicColor.gb');
    return await buildDotNetGraphicColorGenerated(jsObject, layerId, viewId);
}
