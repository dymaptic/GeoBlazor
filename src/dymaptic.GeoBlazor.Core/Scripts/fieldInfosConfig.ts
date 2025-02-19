
export async function buildJsFieldInfosConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldInfosConfigGenerated } = await import('./fieldInfosConfig.gb');
    return await buildJsFieldInfosConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldInfosConfig(jsObject: any): Promise<any> {
    let { buildDotNetFieldInfosConfigGenerated } = await import('./fieldInfosConfig.gb');
    return await buildDotNetFieldInfosConfigGenerated(jsObject);
}
