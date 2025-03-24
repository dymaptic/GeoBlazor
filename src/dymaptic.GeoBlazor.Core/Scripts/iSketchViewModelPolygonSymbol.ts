import {buildDotNetSymbol, buildJsSymbol} from "./symbol";

export function buildJsISketchViewModelPolygonSymbol(dotNetObject: any): Promise<any> {
    return buildJsSymbol(dotNetObject);
}

export function buildDotNetISketchViewModelPolygonSymbol(jsObject: any): Promise<any> {
    return buildDotNetSymbol(jsObject);
}
