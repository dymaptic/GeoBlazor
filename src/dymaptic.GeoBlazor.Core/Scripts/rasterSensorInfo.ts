
export async function buildJsRasterSensorInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildJsRasterSensorInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetRasterSensorInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildDotNetRasterSensorInfoGenerated(jsObject, viewId);
}
