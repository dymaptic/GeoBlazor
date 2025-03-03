
export async function buildJsProjectParametersTransformation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProjectParametersTransformationGenerated } = await import('./projectParametersTransformation.gb');
    return await buildJsProjectParametersTransformationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProjectParametersTransformation(jsObject: any): Promise<any> {
    let { buildDotNetProjectParametersTransformationGenerated } = await import('./projectParametersTransformation.gb');
    return await buildDotNetProjectParametersTransformationGenerated(jsObject);
}
