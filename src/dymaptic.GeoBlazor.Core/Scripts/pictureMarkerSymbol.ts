// override generated code in this file
import PictureMarkerSymbolGenerated from './pictureMarkerSymbol.gb';
import PictureMarkerSymbol from '@arcgis/core/symbols/PictureMarkerSymbol';

export default class PictureMarkerSymbolWrapper extends PictureMarkerSymbolGenerated {

    constructor(component: PictureMarkerSymbol) {
        super(component);
    }
    
}

export async function buildJsPictureMarkerSymbol(dotNetObject: any): Promise<any> {
    let { buildJsPictureMarkerSymbolGenerated } = await import('./pictureMarkerSymbol.gb');
    return await buildJsPictureMarkerSymbolGenerated(dotNetObject);
}     

export async function buildDotNetPictureMarkerSymbol(jsObject: any): Promise<any> {
    let { buildDotNetPictureMarkerSymbolGenerated } = await import('./pictureMarkerSymbol.gb');
    return await buildDotNetPictureMarkerSymbolGenerated(jsObject);
}
