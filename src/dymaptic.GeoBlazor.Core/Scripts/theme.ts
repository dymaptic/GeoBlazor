
export async function buildJsTheme(dotNetObject: any): Promise<any> {
    let { buildJsThemeGenerated } = await import('./theme.gb');
    return await buildJsThemeGenerated(dotNetObject);
}     

export async function buildDotNetTheme(jsObject: any): Promise<any> {
    let { buildDotNetThemeGenerated } = await import('./theme.gb');
    return await buildDotNetThemeGenerated(jsObject);
}
