
export async function buildJsRasterSensorInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildJsRasterSensorInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterSensorInfo(jsObject: any): Promise<any> {
    let { buildDotNetRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildDotNetRasterSensorInfoGenerated(jsObject);
}
