export async function buildJsFieldInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFieldInputGenerated} = await import('./fieldInput.gb');
    return await buildJsFieldInputGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFieldInput(jsObject: any): Promise<any> {
    let {buildDotNetFieldInputGenerated} = await import('./fieldInput.gb');
    return await buildDotNetFieldInputGenerated(jsObject);
}
