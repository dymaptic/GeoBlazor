// override generated code in this file

export async function buildJsWMSSublayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsWMSSublayerGenerated} = await import('./wMSSublayer.gb');
    return await buildJsWMSSublayerGenerated(dotNetObject, viewId);
}

export async function buildDotNetWMSSublayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWMSSublayerGenerated} = await import('./wMSSublayer.gb');
    return await buildDotNetWMSSublayerGenerated(jsObject, viewId);
}
