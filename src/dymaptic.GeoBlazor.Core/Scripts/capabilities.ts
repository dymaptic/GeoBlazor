import {removeCircularReferences} from "./arcGisJsInterop";

export async function buildJsCapabilities(dotNetObject: any): Promise<any> {
    // NOT USED, PLACEHOLDER
}     

export async function buildDotNetCapabilities(jsObject: any): Promise<any> {
    return removeCircularReferences(jsObject);
}
