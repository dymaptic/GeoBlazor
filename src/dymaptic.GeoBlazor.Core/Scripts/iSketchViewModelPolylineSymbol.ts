import {buildDotNetSymbol, buildJsSymbol} from "./symbol";

export function buildJsISketchViewModelPolylineSymbol(dotNetObject: any): Promise<any> {
    return buildJsSymbol(dotNetObject);
}

export function buildDotNetISketchViewModelPolylineSymbol(jsObject: any): Promise<any> {
    return buildDotNetSymbol(jsObject);
}
