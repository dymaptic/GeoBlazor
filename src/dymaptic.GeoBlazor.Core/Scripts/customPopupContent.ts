// PLACEHOLDER FOR GEOBLAZOR PRO IMPLEMENTATION

import { sanitize } from './geoBlazorCore';

// don't remove the layerId and viewId parameters, they are used in the Pro implementation
export function buildJsCustomPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return sanitize(dotNetObject);
}

export function buildDotNetCustomPopupContent(jsObject: any): any {
    return jsObject;
}
