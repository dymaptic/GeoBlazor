import {removeCircularReferences, sanitize} from "./geoBlazorCore";

export function buildDotNetWCSCapabilitiesGenerated(jsObject: any): any {
    return removeCircularReferences(jsObject);
}

export function buildJsWCSCapabilitiesGenerated(dotNetObject: any): any {
    return sanitize(dotNetObject);
}