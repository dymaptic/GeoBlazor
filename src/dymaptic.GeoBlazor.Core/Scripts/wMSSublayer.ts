// override generated code in this file

export async function buildJsWMSSublayer(dotNetObject: any): Promise<any> {
    let {buildJsWMSSublayerGenerated} = await import('./wMSSublayer.gb');
    return await buildJsWMSSublayerGenerated(dotNetObject);
}

export async function buildDotNetWMSSublayer(jsObject: any): Promise<any> {
    let {buildDotNetWMSSublayerGenerated} = await import('./wMSSublayer.gb');
    return await buildDotNetWMSSublayerGenerated(jsObject);
}
