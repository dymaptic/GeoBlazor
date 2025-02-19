export async function buildJsUtilsGetSupportedRendererInfoParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilsGetSupportedRendererInfoParamsGenerated } = await import('./utilsGetSupportedRendererInfoParams.gb');
    return await buildJsUtilsGetSupportedRendererInfoParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUtilsGetSupportedRendererInfoParams(jsObject: any): Promise<any> {
    let { buildDotNetUtilsGetSupportedRendererInfoParamsGenerated } = await import('./utilsGetSupportedRendererInfoParams.gb');
    return await buildDotNetUtilsGetSupportedRendererInfoParamsGenerated(jsObject);
}
