export async function buildJsTypeCreatePCClassRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeCreatePCClassRendererParamsGenerated} = await import('./typeCreatePCClassRendererParams.gb');
    return await buildJsTypeCreatePCClassRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeCreatePCClassRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetTypeCreatePCClassRendererParamsGenerated} = await import('./typeCreatePCClassRendererParams.gb');
    return await buildDotNetTypeCreatePCClassRendererParamsGenerated(jsObject);
}
