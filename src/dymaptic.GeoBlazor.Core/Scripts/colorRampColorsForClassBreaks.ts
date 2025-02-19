export async function buildJsColorRampColorsForClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorRampColorsForClassBreaksGenerated } = await import('./colorRampColorsForClassBreaks.gb');
    return await buildJsColorRampColorsForClassBreaksGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetColorRampColorsForClassBreaks(jsObject: any): Promise<any> {
    let { buildDotNetColorRampColorsForClassBreaksGenerated } = await import('./colorRampColorsForClassBreaks.gb');
    return await buildDotNetColorRampColorsForClassBreaksGenerated(jsObject);
}
