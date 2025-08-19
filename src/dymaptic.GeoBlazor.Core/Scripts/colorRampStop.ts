export async function buildJsColorRampStop(dotNetObject: any): Promise<any> {
    let {buildJsColorRampStopGenerated} = await import('./colorRampStop.gb');
    return await buildJsColorRampStopGenerated(dotNetObject);
}

export async function buildDotNetColorRampStop(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetColorRampStopGenerated} = await import('./colorRampStop.gb');
    return await buildDotNetColorRampStopGenerated(jsObject, viewId);
}
