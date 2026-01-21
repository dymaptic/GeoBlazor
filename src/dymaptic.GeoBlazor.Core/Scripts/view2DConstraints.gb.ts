import {removeCircularReferences, sanitize} from "./geoBlazorCore";

export async function buildJsView2DConstraintsGenerated(dotNetObject: any): Promise<any> {
    return sanitize(dotNetObject);
}

export async function buildDotNetView2DConstraintsGenerated(jsObject: any): Promise<any> {
    return removeCircularReferences(jsObject)
}