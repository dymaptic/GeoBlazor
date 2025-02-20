export async function buildJsDensifyParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDensifyParametersGenerated} = await import('./densifyParameters.gb');
    return await buildJsDensifyParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDensifyParameters(jsObject: any): Promise<any> {
    let {buildDotNetDensifyParametersGenerated} = await import('./densifyParameters.gb');
    return await buildDotNetDensifyParametersGenerated(jsObject);
}
