// override generated code in this file

export async function buildJsWMTSSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMTSSublayerGenerated} = await import('./wMTSSublayer.gb');
    return await buildJsWMTSSublayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMTSSublayer(jsObject: any): Promise<any> {
    let {buildDotNetWMTSSublayerGenerated} = await import('./wMTSSublayer.gb');
    return await buildDotNetWMTSSublayerGenerated(jsObject);
}
