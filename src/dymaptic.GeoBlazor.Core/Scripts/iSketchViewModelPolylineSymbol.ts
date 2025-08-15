import {buildDotNetSymbol, buildJsSymbol} from "./symbol";

export function buildJsISketchViewModelPolylineSymbol(dotNetObject: any, viewId: string | null): any {
    return buildJsSymbol(dotNetObject);
}

export function buildDotNetISketchViewModelPolylineSymbol(jsObject: any, viewId: string | null): any {
    return buildDotNetSymbol(jsObject);
}
