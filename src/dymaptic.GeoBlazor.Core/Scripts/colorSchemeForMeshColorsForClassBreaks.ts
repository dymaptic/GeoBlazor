export async function buildJsColorSchemeForMeshColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSchemeForMeshColorsForClassBreaksGenerated } = await import('./colorSchemeForMeshColorsForClassBreaks.gb');
    return await buildJsColorSchemeForMeshColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetColorSchemeForMeshColorsForClassBreaks(jsObject: any): Promise<any> {
    let { buildDotNetColorSchemeForMeshColorsForClassBreaksGenerated } = await import('./colorSchemeForMeshColorsForClassBreaks.gb');
    return await buildDotNetColorSchemeForMeshColorsForClassBreaksGenerated(jsObject);
}
