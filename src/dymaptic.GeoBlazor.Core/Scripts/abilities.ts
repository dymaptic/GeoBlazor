
export async function buildJsAbilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAbilitiesGenerated } = await import('./abilities.gb');
    return await buildJsAbilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAbilities(jsObject: any): Promise<any> {
    let { buildDotNetAbilitiesGenerated } = await import('./abilities.gb');
    return await buildDotNetAbilitiesGenerated(jsObject);
}
