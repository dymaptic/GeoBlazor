
export async function buildJsCIMStroke(dotNetObject: any): Promise<any> {
    let { buildJsCIMStrokeGenerated } = await import('./cIMStroke.gb');
    return await buildJsCIMStrokeGenerated(dotNetObject);
}     

export async function buildDotNetCIMStroke(jsObject: any): Promise<any> {
    let { buildDotNetCIMStrokeGenerated } = await import('./cIMStroke.gb');
    return await buildDotNetCIMStrokeGenerated(jsObject);
}
