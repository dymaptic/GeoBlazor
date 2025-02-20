export async function buildJsColorSchemeForPolylineColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSchemeForPolylineColorsForClassBreaksGenerated} = await import('./colorSchemeForPolylineColorsForClassBreaks.gb');
    return await buildJsColorSchemeForPolylineColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSchemeForPolylineColorsForClassBreaks(jsObject: any): Promise<any> {
    let {buildDotNetColorSchemeForPolylineColorsForClassBreaksGenerated} = await import('./colorSchemeForPolylineColorsForClassBreaks.gb');
    return await buildDotNetColorSchemeForPolylineColorsForClassBreaksGenerated(jsObject);
}
