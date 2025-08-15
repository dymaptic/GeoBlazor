import {removeCircularReferences} from "./arcGisJsInterop";

export async function buildJsCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    // NOT USED, PLACEHOLDER
}     

export async function buildDotNetCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    return removeCircularReferences(jsObject);
}
