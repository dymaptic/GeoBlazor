import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export async function buildJsPopupDockOptions(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsPopupDockOptions: any = {};

    if (hasValue(dotNetObject.breakPoint)) {
        jsPopupDockOptions.breakpoint = dotNetObject.breakPoint;
    }
    if (hasValue(dotNetObject.buttonEnabled)) {
        jsPopupDockOptions.buttonEnabled = dotNetObject.buttonEnabled;
    }
    if (hasValue(dotNetObject.position)) {
        jsPopupDockOptions.position = dotNetObject.position;
    }

    jsObjectRefs[dotNetObject.id] = jsPopupDockOptions;
    arcGisObjectRefs[dotNetObject.id] = jsPopupDockOptions;

    return jsPopupDockOptions;
}     

export async function buildDotNetPopupDockOptions(jsObject: any): Promise<any> {
    let { buildDotNetPopupDockOptionsGenerated } = await import('./popupDockOptions.gb');
    return await buildDotNetPopupDockOptionsGenerated(jsObject);
}
