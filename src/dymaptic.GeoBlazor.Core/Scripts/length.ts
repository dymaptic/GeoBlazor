
export async function buildJsLength(dotNetObject: any): Promise<any> {
    let { buildJsLengthGenerated } = await import('./length.gb');
    return await buildJsLengthGenerated(dotNetObject);
}     

export async function buildDotNetLength(jsObject: any): Promise<any> {
    let { buildDotNetLengthGenerated } = await import('./length.gb');
    return await buildDotNetLengthGenerated(jsObject);
}
