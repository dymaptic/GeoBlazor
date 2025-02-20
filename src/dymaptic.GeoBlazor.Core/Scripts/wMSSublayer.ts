// override generated code in this file

export async function buildJsWMSSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMSSublayerGenerated} = await import('./wMSSublayer.gb');
    return await buildJsWMSSublayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMSSublayer(jsObject: any): Promise<any> {
    let {buildDotNetWMSSublayerGenerated} = await import('./wMSSublayer.gb');
    return await buildDotNetWMSSublayerGenerated(jsObject);
}
