
export async function buildJsLength(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLengthGenerated } = await import('./length.gb');
    return await buildJsLengthGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLength(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLengthGenerated } = await import('./length.gb');
    return await buildDotNetLengthGenerated(jsObject, viewId);
}
