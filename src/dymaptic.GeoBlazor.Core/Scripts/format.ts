// override generated code in this file

export async function buildJsFormat(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFormatGenerated} = await import('./format.gb');
    return await buildJsFormatGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFormat(jsObject: any): Promise<any> {
    let {buildDotNetFormatGenerated} = await import('./format.gb');
    return await buildDotNetFormatGenerated(jsObject);
}
