export async function buildJsVectorFieldCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVectorFieldCreateRendererParamsGenerated} = await import('./vectorFieldCreateRendererParams.gb');
    return await buildJsVectorFieldCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVectorFieldCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetVectorFieldCreateRendererParamsGenerated} = await import('./vectorFieldCreateRendererParams.gb');
    return await buildDotNetVectorFieldCreateRendererParamsGenerated(jsObject);
}
