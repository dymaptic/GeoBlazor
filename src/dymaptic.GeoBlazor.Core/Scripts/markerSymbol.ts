export async function buildJsMarkerSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject.type) {
        case 'simple-marker':
            let {buildJsSimpleMarkerSymbol} = await import('./simpleMarkerSymbol');
            return await buildJsSimpleMarkerSymbol(dotNetObject, layerId, viewId);
        case 'picture-marker':
            let {buildJsPictureMarkerSymbol} = await import('./pictureMarkerSymbol');
            return await buildJsPictureMarkerSymbol(dotNetObject, layerId, viewId);
    }
    
    return null;
}
export async function buildDotNetMarkerSymbol(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMarkerSymbolGenerated } = await import('./MarkerSymbol.gb');
    return await buildDotNetMarkerSymbolGenerated(jsObject, layerId);
}