export async function buildJsCamera(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCameraGenerated} = await import('./camera.gb');
    return await buildJsCameraGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCamera(jsObject: any): Promise<any> {
    let {buildDotNetCameraGenerated} = await import('./camera.gb');
    return await buildDotNetCameraGenerated(jsObject);
}
