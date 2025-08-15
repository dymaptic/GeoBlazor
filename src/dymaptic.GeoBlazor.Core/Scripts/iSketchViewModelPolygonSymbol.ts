import {buildDotNetSymbol, buildJsSymbol} from "./symbol";

export function buildJsISketchViewModelPolygonSymbol(dotNetObject: any, viewId: string | null): any {
    return buildJsSymbol(dotNetObject);
}

export function buildDotNetISketchViewModelPolygonSymbol(jsObject: any, viewId: string | null): any {
    return buildDotNetSymbol(jsObject);
}
