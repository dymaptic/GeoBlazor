import {buildDotNetPoint, buildJsPoint} from './point';

export function buildJsSuggestResult(dotNetObject: any, viewId: string | null): any {
    let jsPoint = buildJsPoint(dotNetObject.location);
    let result: any = {
        location: jsPoint
    };
    
    if (dotNetObject.hasOwnProperty('key')) {
        result.key = dotNetObject.key;
    }
    if (dotNetObject.hasOwnProperty('text')) {
        result.text = dotNetObject.text;
    }
    if (dotNetObject.hasOwnProperty('sourceIndex')) {
        result.sourceIndex = dotNetObject.sourceIndex;
    }
    return result;
}

export function buildDotNetSuggestResult(jsObject: any, viewId: string | null): any {
    let dnPoint = buildDotNetPoint(jsObject.location);
    return {
        location: dnPoint,
        key: jsObject.key,
        text: jsObject.text,
        sourceIndex: jsObject.sourceIndex
    };
}
