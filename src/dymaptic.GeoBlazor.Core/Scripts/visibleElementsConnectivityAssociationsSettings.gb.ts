// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetVisibleElementsConnectivityAssociationsSettings } from './visibleElementsConnectivityAssociationsSettings';

export async function buildJsVisibleElementsConnectivityAssociationsSettingsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsVisibleElementsConnectivityAssociationsSettings: any = {};

    if (hasValue(dotNetObject.arrowsToggle)) {
        jsVisibleElementsConnectivityAssociationsSettings.arrowsToggle = dotNetObject.arrowsToggle;
    }
    if (hasValue(dotNetObject.capSelect)) {
        jsVisibleElementsConnectivityAssociationsSettings.capSelect = dotNetObject.capSelect;
    }
    if (hasValue(dotNetObject.colorPicker)) {
        jsVisibleElementsConnectivityAssociationsSettings.colorPicker = dotNetObject.colorPicker;
    }
    if (hasValue(dotNetObject.stylePicker)) {
        jsVisibleElementsConnectivityAssociationsSettings.stylePicker = dotNetObject.stylePicker;
    }
    if (hasValue(dotNetObject.widthInput)) {
        jsVisibleElementsConnectivityAssociationsSettings.widthInput = dotNetObject.widthInput;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsVisibleElementsConnectivityAssociationsSettings);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsVisibleElementsConnectivityAssociationsSettings;
    
    return jsVisibleElementsConnectivityAssociationsSettings;
}


export async function buildDotNetVisibleElementsConnectivityAssociationsSettingsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetVisibleElementsConnectivityAssociationsSettings: any = {};
    
    if (hasValue(jsObject.arrowsToggle)) {
        dotNetVisibleElementsConnectivityAssociationsSettings.arrowsToggle = jsObject.arrowsToggle;
    }
    
    if (hasValue(jsObject.capSelect)) {
        dotNetVisibleElementsConnectivityAssociationsSettings.capSelect = jsObject.capSelect;
    }
    
    if (hasValue(jsObject.colorPicker)) {
        dotNetVisibleElementsConnectivityAssociationsSettings.colorPicker = jsObject.colorPicker;
    }
    
    if (hasValue(jsObject.stylePicker)) {
        dotNetVisibleElementsConnectivityAssociationsSettings.stylePicker = jsObject.stylePicker;
    }
    
    if (hasValue(jsObject.widthInput)) {
        dotNetVisibleElementsConnectivityAssociationsSettings.widthInput = jsObject.widthInput;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetVisibleElementsConnectivityAssociationsSettings.id = geoBlazorId;
    }

    return dotNetVisibleElementsConnectivityAssociationsSettings;
}

