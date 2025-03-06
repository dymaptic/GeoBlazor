
export async function buildJsRenderCamera(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRenderCameraGenerated } = await import('./renderCamera.gb');
    return await buildJsRenderCameraGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRenderCamera(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRenderCameraGenerated } = await import('./renderCamera.gb');
    return await buildDotNetRenderCameraGenerated(jsObject, layerId, viewId);
}
