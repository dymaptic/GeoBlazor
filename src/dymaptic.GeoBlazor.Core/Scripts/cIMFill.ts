
export async function buildJsCIMFill(dotNetObject: any): Promise<any> {
    let { buildJsCIMFillGenerated } = await import('./cIMFill.gb');
    return await buildJsCIMFillGenerated(dotNetObject);
}     

export async function buildDotNetCIMFill(jsObject: any): Promise<any> {
    let { buildDotNetCIMFillGenerated } = await import('./cIMFill.gb');
    return await buildDotNetCIMFillGenerated(jsObject);
}
