import {buildDotNetSymbol, buildJsSymbol} from "./symbol";

export function buildJsISketchViewModelPointSymbol(dotNetObject: any, viewId: string | null): any {
    return buildJsSymbol(dotNetObject);
}

export function buildDotNetISketchViewModelPointSymbol(jsObject: any, viewId: string | null): any {
    return buildDotNetSymbol(jsObject);
}
