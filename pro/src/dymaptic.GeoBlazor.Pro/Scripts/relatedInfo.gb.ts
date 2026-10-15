import {removeCircularReferences, sanitize} from "./geoBlazorCore";

export async function buildJsRelatedInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    return sanitize(dotNetObject);
}

export async function buildDotNetRelatedInfoGenerated(jsObject: any, viewId: string | null): Promise<any> {
    return removeCircularReferences(jsObject);
}