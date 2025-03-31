import {buildDotNetSymbol, buildJsSymbol} from "./symbol";

export function buildJsISketchViewModelPointSymbol(dotNetObject: any): Promise<any> {
    return buildJsSymbol(dotNetObject);
}

export function buildDotNetISketchViewModelPointSymbol(jsObject: any): Promise<any> {
    return buildDotNetSymbol(jsObject);
}
