export async function buildJsColorSchemeForPointColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSchemeForPointColorsForClassBreaksGenerated} = await import('./colorSchemeForPointColorsForClassBreaks.gb');
    return await buildJsColorSchemeForPointColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSchemeForPointColorsForClassBreaks(jsObject: any): Promise<any> {
    let {buildDotNetColorSchemeForPointColorsForClassBreaksGenerated} = await import('./colorSchemeForPointColorsForClassBreaks.gb');
    return await buildDotNetColorSchemeForPointColorsForClassBreaksGenerated(jsObject);
}
