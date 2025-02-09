// override generated code in this file
import PictureFillSymbolGenerated from './pictureFillSymbol.gb';
import PictureFillSymbol from '@arcgis/core/symbols/PictureFillSymbol';

export default class PictureFillSymbolWrapper extends PictureFillSymbolGenerated {

    constructor(component: PictureFillSymbol) {
        super(component);
    }
    
}

export async function buildJsPictureFillSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPictureFillSymbolGenerated } = await import('./pictureFillSymbol.gb');
    return await buildJsPictureFillSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPictureFillSymbol(jsObject: any): Promise<any> {
    let { buildDotNetPictureFillSymbolGenerated } = await import('./pictureFillSymbol.gb');
    return await buildDotNetPictureFillSymbolGenerated(jsObject);
}
