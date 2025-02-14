// override generated code in this file
import SymbolGenerated from './symbol.gb';
import Symbol from '@arcgis/core/symbols/Symbol';

export default class SymbolWrapper extends SymbolGenerated {

    constructor(component: Symbol) {
        super(component);
    }
    
}

export async function buildJsSymbol(symbol: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (symbol?.type) {
        case "simple-marker":
            let { buildJsSimpleMarkerSymbol } = await import('./simpleMarkerSymbol');
            return await buildJsSimpleMarkerSymbol(symbol, layerId, viewId);
        case "simple-line":
            let { buildJsSimpleLineSymbol } = await import('./simpleLineSymbol');
            return await buildJsSimpleLineSymbol(symbol, layerId, viewId);
        case "picture-marker":
            let { buildJsPictureMarkerSymbol } = await import('./pictureMarkerSymbol');
            return await buildJsPictureMarkerSymbol(symbol, layerId, viewId);
        case "picture-fill":
            let { buildJsPictureFillSymbol } = await import('./pictureFillSymbol');
            return await buildJsPictureFillSymbol(symbol, layerId, viewId);
        case "simple-fill":
            let { buildJsSimpleFillSymbol } = await import('./simpleFillSymbol');
            return await buildJsSimpleFillSymbol(symbol, layerId, viewId);
        case "text":
            let { buildJsTextSymbol } = await import('./textSymbol');
            return await buildJsTextSymbol(symbol, layerId, viewId);
        default:
            throw new Error('Unknown symbol type');
    }
}

export async function buildDotNetSymbol(symbol: Symbol): Promise<any> {
    switch (symbol.type) {
        case 'picture-fill':
            let {buildDotNetPictureFillSymbol} = await import('./pictureFillSymbol');
            return await buildDotNetPictureFillSymbol(symbol);
        case 'picture-marker':
            let {buildDotNetPictureMarkerSymbol} = await import('./pictureMarkerSymbol');
            return await buildDotNetPictureMarkerSymbol(symbol);
        case 'simple-fill':
            let {buildDotNetSimpleFillSymbol} = await import('./simpleFillSymbol');
            return await buildDotNetSimpleFillSymbol(symbol);
        case 'simple-line':
            let {buildDotNetSimpleLineSymbol} = await import('./simpleLineSymbol');
            return await buildDotNetSimpleLineSymbol(symbol);
        case 'simple-marker':
            let {buildDotNetSimpleMarkerSymbol} = await import('./simpleMarkerSymbol');
            return await buildDotNetSimpleMarkerSymbol(symbol);
        case 'text':
            let {buildDotNetTextSymbol} = await import('./textSymbol');
            return await buildDotNetTextSymbol(symbol);
        default:
            throw new Error('Unknown symbol type');
    }
}