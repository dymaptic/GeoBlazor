export async function buildJsSizeRampStop(dotNetObject: any): Promise<any> {
    let {buildJsSizeRampStopGenerated} = await import('./sizeRampStop.gb');
    return await buildJsSizeRampStopGenerated(dotNetObject);
}

export async function buildDotNetSizeRampStop(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetSizeRampStopGenerated} = await import('./sizeRampStop.gb');
    return await buildDotNetSizeRampStopGenerated(jsObject, viewId);
}
