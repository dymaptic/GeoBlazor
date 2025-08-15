
export async function buildJsTheme(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsThemeGenerated } = await import('./theme.gb');
    return await buildJsThemeGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTheme(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetThemeGenerated } = await import('./theme.gb');
    return await buildDotNetThemeGenerated(jsObject, viewId);
}
