export async function buildJsFlowCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFlowCreateRendererParamsGenerated} = await import('./flowCreateRendererParams.gb');
    return await buildJsFlowCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFlowCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetFlowCreateRendererParamsGenerated} = await import('./flowCreateRendererParams.gb');
    return await buildDotNetFlowCreateRendererParamsGenerated(jsObject);
}
