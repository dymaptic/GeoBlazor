export async function buildJsMarkerSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject.type) {
        case 'simple-marker':
            let {buildJsSimpleMarkerSymbol} = await import('./simpleMarkerSymbol');
            return await buildJsSimpleMarkerSymbol(dotNetObject);
        case 'picture-marker':
            let {buildJsPictureMarkerSymbol} = await import('./pictureMarkerSymbol');
            return await buildJsPictureMarkerSymbol(dotNetObject, layerId, viewId);
    }
    
    return null;
}
export async function buildDotNetMarkerSymbol(jsObject: any): Promise<any> {
    switch (jsObject.type) {
        case 'simple-marker':
            let {buildDotNetSimpleMarkerSymbol} = await import('./simpleMarkerSymbol');
            return await buildDotNetSimpleMarkerSymbol(jsObject);
        case 'picture-marker':
            let {buildDotNetPictureMarkerSymbol} = await import('./pictureMarkerSymbol');
            return await buildDotNetPictureMarkerSymbol(jsObject);
    }
}