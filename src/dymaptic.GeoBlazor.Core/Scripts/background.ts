
export async function buildJsBackground(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBackgroundGenerated } = await import('./background.gb');
    return await buildJsBackgroundGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBackground(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBackgroundGenerated } = await import('./background.gb');
    return await buildDotNetBackgroundGenerated(jsObject, viewId);
}
