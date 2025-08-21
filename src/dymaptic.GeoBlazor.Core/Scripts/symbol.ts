// override generated code in this file
import {buildDotNetSimpleMarkerSymbol, buildJsSimpleMarkerSymbol} from './simpleMarkerSymbol';
import {buildDotNetSimpleLineSymbol, buildJsSimpleLineSymbol} from './simpleLineSymbol';
import {buildDotNetPictureMarkerSymbol, buildJsPictureMarkerSymbol} from "./pictureMarkerSymbol";
import {buildDotNetPictureFillSymbol, buildJsPictureFillSymbol} from "./pictureFillSymbol";
import {buildDotNetSimpleFillSymbol, buildJsSimpleFillSymbol} from './simpleFillSymbol';
import {buildDotNetTextSymbol, buildJsTextSymbol} from "./textSymbol";
import {buildDotNetWebStyleSymbol, buildJsWebStyleSymbol} from "./webStyleSymbol";
import {hasValue, sanitize} from "./arcGisJsInterop";

export function buildJsSymbol(symbol: any, layerId: string | null, viewId: string | null): any {
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
        case "web-style":
            return buildJsWebStyleSymbol(symbol, layerId, viewId);
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
        case 'web-style':
            return buildDotNetWebStyleSymbol(symbol, viewId);
        default:
            return symbol;
    }
}
