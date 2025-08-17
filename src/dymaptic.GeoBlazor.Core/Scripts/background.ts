
export async function buildJsBackground(dotNetObject: any): Promise<any> {
    let { buildJsBackgroundGenerated } = await import('./background.gb');
    return await buildJsBackgroundGenerated(dotNetObject);
}     

export async function buildDotNetBackground(jsObject: any): Promise<any> {
    let { buildDotNetBackgroundGenerated } = await import('./background.gb');
    return await buildDotNetBackgroundGenerated(jsObject);
}
