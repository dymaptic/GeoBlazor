// PLACEHOLDER FOR GEOBLAZOR PRO IMPLEMENTATION

import { sanitize } from './arcGisJsInterop';

export function buildJsCustomPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return sanitize(dotNetObject);
}

export function buildDotNetCustomPopupContent(jsObject: any): any {
    return jsObject;
}
