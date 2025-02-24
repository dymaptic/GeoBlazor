// override generated code in this file
import Symbol from '@arcgis/core/symbols/Symbol';
import {buildDotNetSimpleMarkerSymbol, buildJsSimpleMarkerSymbol} from './simpleMarkerSymbol';
import {buildDotNetSimpleLineSymbol, buildJsSimpleLineSymbol} from './simpleLineSymbol';
import {buildDotNetPictureMarkerSymbol, buildJsPictureMarkerSymbol} from "./pictureMarkerSymbol";
import {buildDotNetPictureFillSymbol, buildJsPictureFillSymbol} from "./pictureFillSymbol";
import {buildDotNetSimpleFillSymbol, buildJsSimpleFillSymbol} from './simpleFillSymbol';
import {buildDotNetTextSymbol, buildJsTextSymbol} from "./textSymbol";
import {hasValue} from "./arcGisJsInterop";

export function buildJsSymbol(symbol: any): any {
    if (!hasValue(symbol)) {
        return null;
    }
    switch (symbol?.type) {
        case "simple-marker":
            return buildJsSimpleMarkerSymbol(symbol);
        case "simple-line":
            return buildJsSimpleLineSymbol(symbol);
        case "picture-marker":
            return buildJsPictureMarkerSymbol(symbol);
        case "picture-fill":
            return buildJsPictureFillSymbol(symbol);
        case "simple-fill":
            return buildJsSimpleFillSymbol(symbol);
        case "text":
            return buildJsTextSymbol(symbol);
        default:
            let { id, dotNetComponentReference, sanitizedSymbol } = symbol;
            return sanitizedSymbol;
    }
}

export function buildDotNetSymbol(symbol: Symbol): any {
    if (!hasValue(symbol)) {
        return null;
    }
    switch (symbol.type) {
        case 'picture-fill':
            return buildDotNetPictureFillSymbol(symbol);
        case 'picture-marker':
            return buildDotNetPictureMarkerSymbol(symbol);
        case 'simple-fill':
            return buildDotNetSimpleFillSymbol(symbol);
        case 'simple-line':
            return buildDotNetSimpleLineSymbol(symbol);
        case 'simple-marker':
            return buildDotNetSimpleMarkerSymbol(symbol);
        case 'text':
            return buildDotNetTextSymbol(symbol);
        default:
            return symbol;
    }
}
