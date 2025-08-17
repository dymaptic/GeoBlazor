export async function buildJsSizeRampElement(dotNetObject: any): Promise<any> {
    let {buildJsSizeRampElementGenerated} = await import('./sizeRampElement.gb');
    return await buildJsSizeRampElementGenerated(dotNetObject);
}

export async function buildDotNetSizeRampElement(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetSizeRampElementGenerated} = await import('./sizeRampElement.gb');
    return await buildDotNetSizeRampElementGenerated(jsObject, viewId);
}
