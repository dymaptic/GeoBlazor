// override generated code in this file
import Symbol from '@arcgis/core/symbols/Symbol';
import {buildDotNetSimpleMarkerSymbol, buildJsSimpleMarkerSymbol} from './simpleMarkerSymbol';
import {buildDotNetSimpleLineSymbol, buildJsSimpleLineSymbol} from './simpleLineSymbol';
import {buildDotNetPictureMarkerSymbol, buildJsPictureMarkerSymbol} from "./pictureMarkerSymbol";
import {buildDotNetPictureFillSymbol, buildJsPictureFillSymbol} from "./pictureFillSymbol";
import {buildDotNetSimpleFillSymbol, buildJsSimpleFillSymbol} from './simpleFillSymbol';
import {buildDotNetTextSymbol, buildJsTextSymbol} from "./textSymbol";
import {hasValue, sanitize} from "./arcGisJsInterop";

export function buildJsSymbol(symbol: any, viewId: string | null): any {
    if (!hasValue(symbol)) {
        return null;
    }
    switch (symbol?.type) {
        case "simple-marker":
            return buildJsSimpleMarkerSymbol(symbol, viewId);
        case "simple-line":
            return buildJsSimpleLineSymbol(symbol, viewId);
        case "picture-marker":
            return buildJsPictureMarkerSymbol(symbol, viewId);
        case "picture-fill":
            return buildJsPictureFillSymbol(symbol, viewId);
        case "simple-fill":
            return buildJsSimpleFillSymbol(symbol, viewId);
        case "text":
            return buildJsTextSymbol(symbol, viewId);
        default:
            return sanitize(symbol);
    }
}

export function buildDotNetSymbol(symbol: any, viewId: string | null): any {
    if (!hasValue(symbol)) {
        return null;
    }
    switch (symbol.type) {
        case 'picture-fill':
            return buildDotNetPictureFillSymbol(symbol, viewId);
        case 'picture-marker':
            return buildDotNetPictureMarkerSymbol(symbol, viewId);
        case 'simple-fill':
            return buildDotNetSimpleFillSymbol(symbol, viewId);
        case 'simple-line':
            return buildDotNetSimpleLineSymbol(symbol, viewId);
        case 'simple-marker':
            return buildDotNetSimpleMarkerSymbol(symbol, viewId);
        case 'text':
            return buildDotNetTextSymbol(symbol, viewId);
        default:
            return symbol;
    }
}
