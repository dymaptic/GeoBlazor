// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetCoordinateConversionVisibleElements } from './coordinateConversionVisibleElements';

export async function buildJsCoordinateConversionVisibleElementsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsCoordinateConversionVisibleElements: any = {};

    if (hasValue(dotNetObject.captureButton)) {
        jsCoordinateConversionVisibleElements.captureButton = dotNetObject.captureButton;
    }
    if (hasValue(dotNetObject.editButton)) {
        jsCoordinateConversionVisibleElements.editButton = dotNetObject.editButton;
    }
    if (hasValue(dotNetObject.expandButton)) {
        jsCoordinateConversionVisibleElements.expandButton = dotNetObject.expandButton;
    }
    if (hasValue(dotNetObject.settingsButton)) {
        jsCoordinateConversionVisibleElements.settingsButton = dotNetObject.settingsButton;
    }
    
    jsObjectRefs[dotNetObject.id] = jsCoordinateConversionVisibleElements;
    arcGisObjectRefs[dotNetObject.id] = jsCoordinateConversionVisibleElements;
    
    return jsCoordinateConversionVisibleElements;
}


export async function buildDotNetCoordinateConversionVisibleElementsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCoordinateConversionVisibleElements: any = {};
    
    if (hasValue(jsObject.captureButton)) {
        dotNetCoordinateConversionVisibleElements.captureButton = jsObject.captureButton;
    }
    
    if (hasValue(jsObject.editButton)) {
        dotNetCoordinateConversionVisibleElements.editButton = jsObject.editButton;
    }
    
    if (hasValue(jsObject.expandButton)) {
        dotNetCoordinateConversionVisibleElements.expandButton = jsObject.expandButton;
    }
    
    if (hasValue(jsObject.settingsButton)) {
        dotNetCoordinateConversionVisibleElements.settingsButton = jsObject.settingsButton;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetCoordinateConversionVisibleElements.id = geoBlazorId;
    }

    return dotNetCoordinateConversionVisibleElements;
}

