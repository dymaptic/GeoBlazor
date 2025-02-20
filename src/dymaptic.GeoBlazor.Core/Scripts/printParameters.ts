export async function buildJsPrintParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPrintParametersGenerated} = await import('./printParameters.gb');
    return await buildJsPrintParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPrintParameters(jsObject: any): Promise<any> {
    let {buildDotNetPrintParametersGenerated} = await import('./printParameters.gb');
    return await buildDotNetPrintParametersGenerated(jsObject);
}
