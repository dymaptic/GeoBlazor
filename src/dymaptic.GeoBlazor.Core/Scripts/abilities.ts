
export async function buildJsAbilities(dotNetObject: any): Promise<any> {
    let { buildJsAbilitiesGenerated } = await import('./abilities.gb');
    return await buildJsAbilitiesGenerated(dotNetObject);
}     

export async function buildDotNetAbilities(jsObject: any, layerId: string | null): Promise<any> {
    let { buildDotNetAbilitiesGenerated } = await import('./abilities.gb');
    return await buildDotNetAbilitiesGenerated(jsObject, layerId);
}
