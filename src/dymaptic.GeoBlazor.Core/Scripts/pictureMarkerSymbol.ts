// override generated code in this file
import PictureMarkerSymbolGenerated from './pictureMarkerSymbol.gb';
import PictureMarkerSymbol from '@arcgis/core/symbols/PictureMarkerSymbol';

export default class PictureMarkerSymbolWrapper extends PictureMarkerSymbolGenerated {

    constructor(component: PictureMarkerSymbol) {
        super(component);
    }
    
}

export async function buildJsPictureMarkerSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPictureMarkerSymbolGenerated } = await import('./pictureMarkerSymbol.gb');
    return await buildJsPictureMarkerSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPictureMarkerSymbol(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPictureMarkerSymbolGenerated } = await import('./pictureMarkerSymbol.gb');
    return await buildDotNetPictureMarkerSymbolGenerated(jsObject, layerId, viewId);
}
