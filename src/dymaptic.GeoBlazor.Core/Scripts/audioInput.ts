
export async function buildJsAudioInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAudioInputGenerated } = await import('./audioInput.gb');
    return await buildJsAudioInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAudioInput(jsObject: any): Promise<any> {
    let { buildDotNetAudioInputGenerated } = await import('./audioInput.gb');
    return await buildDotNetAudioInputGenerated(jsObject);
}
