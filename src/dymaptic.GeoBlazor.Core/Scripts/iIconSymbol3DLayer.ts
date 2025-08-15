// override generated code in this file

export async function buildJsIIconSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    try {
        // @ts-ignore requires GeoBlazor Pro
        let {buildJsIconSymbol3DLayer} = await import('./iconSymbol3DLayer');
        return await buildJsIconSymbol3DLayer(dotNetObject, layerId, viewId);
    } catch (e) {
        throw new Error(`IconSymbol3DLayer requires GeoBlazor Pro.`);
    }
}

export async function buildDotNetIIconSymbol3DLayer(jsObject: any, viewId: string | null): Promise<any> {
    try {
        // @ts-ignore requires GeoBlazor Pro
        let {buildDotNetIconSymbol3DLayer} = await import('./iconSymbol3DLayer');
        return await buildDotNetIconSymbol3DLayer(jsObject);
    } catch (e) {
        throw new Error(`IconSymbol3DLayer requires GeoBlazor Pro.`);
    }
}
