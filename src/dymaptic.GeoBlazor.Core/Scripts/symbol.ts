// override generated code in this file
import {buildDotNetSimpleMarkerSymbol, buildJsSimpleMarkerSymbol} from './simpleMarkerSymbol';
import {buildDotNetSimpleLineSymbol, buildJsSimpleLineSymbol} from './simpleLineSymbol';
import {buildDotNetPictureMarkerSymbol, buildJsPictureMarkerSymbol} from "./pictureMarkerSymbol";
import {buildDotNetPictureFillSymbol, buildJsPictureFillSymbol} from "./pictureFillSymbol";
import {buildDotNetSimpleFillSymbol, buildJsSimpleFillSymbol} from './simpleFillSymbol';
import {buildDotNetTextSymbol, buildJsTextSymbol} from "./textSymbol";
import {buildDotNetWebStyleSymbol, buildJsWebStyleSymbol} from "./webStyleSymbol";
import {hasValue, removeCircularReferences, sanitize, updateSymbolForProtobuf, UseStreams} from './geoBlazorCore';
import {DotNetSymbol} from "./definitions";

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
    
    let dnSymbol: DotNetSymbol;
    switch (symbol.type) {
        case 'picture-fill':
            dnSymbol = buildDotNetPictureFillSymbol(symbol);
            break;
        case 'picture-marker':
            dnSymbol = buildDotNetPictureMarkerSymbol(symbol);
            break;
        case 'simple-fill':
            dnSymbol = buildDotNetSimpleFillSymbol(symbol);
            break;
        case 'simple-line':
            dnSymbol = buildDotNetSimpleLineSymbol(symbol);
            break;
        case 'simple-marker':
            dnSymbol = buildDotNetSimpleMarkerSymbol(symbol);
            break;
        case 'text':
            dnSymbol = buildDotNetTextSymbol(symbol);
            break;
        case 'web-style':
            dnSymbol = buildDotNetWebStyleSymbol(symbol, viewId);
            break;
        default:
            dnSymbol = removeCircularReferences(symbol);
            break;
    }
    
    if (UseStreams) {
        updateSymbolForProtobuf(dnSymbol);
    }
}
