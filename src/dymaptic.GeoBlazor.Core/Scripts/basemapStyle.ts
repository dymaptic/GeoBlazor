import {hasValue} from "./arcGisJsInterop";

export async function buildJsBasemapStyle(dotNetObject: any): Promise<any> {
    let jsBasemapStyle: any = {};

    if (hasValue(dotNetObject.language)) {
        jsBasemapStyle.language = dotNetObject.language;
    }
    if (hasValue(dotNetObject.name)) {
        jsBasemapStyle.id = dotNetObject.name;
    }
    if (hasValue(dotNetObject.places)) {
        jsBasemapStyle.places = dotNetObject.places;
    }
    if (hasValue(dotNetObject.serviceUrl)) {
        jsBasemapStyle.serviceUrl = dotNetObject.serviceUrl;
    }
    if (hasValue(dotNetObject.worldview)) {
        jsBasemapStyle.worldview = dotNetObject.worldview;
    }

    return jsBasemapStyle;
}     

export async function buildDotNetBasemapStyle(jsObject: any): Promise<any> {
    let { buildDotNetBasemapStyleGenerated } = await import('./basemapStyle.gb');
    return await buildDotNetBasemapStyleGenerated(jsObject);
}
