
export async function buildJsGamepadInputDevice(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGamepadInputDeviceGenerated } = await import('./gamepadInputDevice.gb');
    return await buildJsGamepadInputDeviceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGamepadInputDevice(jsObject: any): Promise<any> {
    let { buildDotNetGamepadInputDeviceGenerated } = await import('./gamepadInputDevice.gb');
    return await buildDotNetGamepadInputDeviceGenerated(jsObject);
}
