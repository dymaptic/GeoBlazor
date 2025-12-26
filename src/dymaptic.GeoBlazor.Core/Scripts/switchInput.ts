
export async function buildJsSwitchInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSwitchInputGenerated } = await import('./switchInput.gb');
    return await buildJsSwitchInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSwitchInput(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSwitchInputGenerated } = await import('./switchInput.gb');
    return await buildDotNetSwitchInputGenerated(jsObject, viewId);
}
