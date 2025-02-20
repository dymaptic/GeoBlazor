// override generated code in this file

export async function buildJsImageGPSInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageGPSInfoGenerated} = await import('./imageGPSInfo.gb');
    return await buildJsImageGPSInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageGPSInfo(jsObject: any): Promise<any> {
    let {buildDotNetImageGPSInfoGenerated} = await import('./imageGPSInfo.gb');
    return await buildDotNetImageGPSInfoGenerated(jsObject);
}
