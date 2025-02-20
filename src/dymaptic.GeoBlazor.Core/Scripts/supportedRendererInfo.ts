export async function buildJsSupportedRendererInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSupportedRendererInfoGenerated} = await import('./supportedRendererInfo.gb');
    return await buildJsSupportedRendererInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSupportedRendererInfo(jsObject: any): Promise<any> {
    let {buildDotNetSupportedRendererInfoGenerated} = await import('./supportedRendererInfo.gb');
    return await buildDotNetSupportedRendererInfoGenerated(jsObject);
}
