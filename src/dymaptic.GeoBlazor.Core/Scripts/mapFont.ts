// override generated code in this file
import MapFontGenerated from './mapFont.gb';
import MapFont = __esri.Font;

export default class MapFontWrapper extends MapFontGenerated {

    constructor(component: MapFont) {
        super(component);
    }
    
}              
export async function buildJsMapFont(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapFontGenerated } = await import('./mapFont.gb');
    return await buildJsMapFontGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMapFont(jsObject: any): Promise<any> {
    let { buildDotNetMapFontGenerated } = await import('./mapFont.gb');
    return await buildDotNetMapFontGenerated(jsObject);
}
