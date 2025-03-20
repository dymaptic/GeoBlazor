
export async function buildJsRasterSensorInfo(dotNetObject: any): Promise<any> {
    let { buildJsRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildJsRasterSensorInfoGenerated(dotNetObject);
}     

export async function buildDotNetRasterSensorInfo(jsObject: any): Promise<any> {
    let { buildDotNetRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildDotNetRasterSensorInfoGenerated(jsObject);
}
