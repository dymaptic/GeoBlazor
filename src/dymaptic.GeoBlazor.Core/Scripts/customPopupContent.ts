// PLACEHOLDER FOR GEOBLAZOR PRO IMPLEMENTATION

import { sanitize } from './arcGisJsInterop';

export function buildJsCustomPopupContent(dotNetObject: any): any {
    return sanitize(dotNetObject);
}

export function buildDotNetCustomPopupContent(jsObject: any): any {
    return jsObject;
}
