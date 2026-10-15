
export async function buildJsFlagProperty(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlagPropertyGenerated } = await import('./flagProperty.gb');
    return await buildJsFlagPropertyGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFlagProperty(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFlagPropertyGenerated } = await import('./flagProperty.gb');
    return await buildDotNetFlagPropertyGenerated(jsObject, layerId, viewId);
}
