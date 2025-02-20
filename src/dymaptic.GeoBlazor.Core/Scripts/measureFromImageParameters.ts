// override generated code in this file

export async function buildJsMeasureFromImageParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMeasureFromImageParametersGenerated} = await import('./measureFromImageParameters.gb');
    return await buildJsMeasureFromImageParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMeasureFromImageParameters(jsObject: any): Promise<any> {
    let {buildDotNetMeasureFromImageParametersGenerated} = await import('./measureFromImageParameters.gb');
    return await buildDotNetMeasureFromImageParametersGenerated(jsObject);
}
