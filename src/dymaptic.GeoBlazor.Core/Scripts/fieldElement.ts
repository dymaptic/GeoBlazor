
export async function buildJsFieldElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldElementGenerated } = await import('./fieldElement.gb');
    return await buildJsFieldElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldElement(jsObject: any): Promise<any> {
    let { buildDotNetFieldElementGenerated } = await import('./fieldElement.gb');
    return await buildDotNetFieldElementGenerated(jsObject);
}
