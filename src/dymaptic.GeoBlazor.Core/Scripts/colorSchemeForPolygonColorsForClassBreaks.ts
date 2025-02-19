
export async function buildJsColorSchemeForPolygonColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSchemeForPolygonColorsForClassBreaksGenerated } = await import('./colorSchemeForPolygonColorsForClassBreaks.gb');
    return await buildJsColorSchemeForPolygonColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSchemeForPolygonColorsForClassBreaks(jsObject: any): Promise<any> {
    let { buildDotNetColorSchemeForPolygonColorsForClassBreaksGenerated } = await import('./colorSchemeForPolygonColorsForClassBreaks.gb');
    return await buildDotNetColorSchemeForPolygonColorsForClassBreaksGenerated(jsObject);
}
