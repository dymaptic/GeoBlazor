
export async function buildJsCameraLayout(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCameraLayoutGenerated } = await import('./cameraLayout.gb');
    return await buildJsCameraLayoutGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCameraLayout(jsObject: any): Promise<any> {
    let { buildDotNetCameraLayoutGenerated } = await import('./cameraLayout.gb');
    return await buildDotNetCameraLayoutGenerated(jsObject);
}
