export async function buildJsConvertMeshOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsConvertMeshOptionsGenerated} = await import('./convertMeshOptions.gb');
    return await buildJsConvertMeshOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetConvertMeshOptions(jsObject: any): Promise<any> {
    let {buildDotNetConvertMeshOptionsGenerated} = await import('./convertMeshOptions.gb');
    return await buildDotNetConvertMeshOptionsGenerated(jsObject);
}
