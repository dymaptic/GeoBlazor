// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import TextBoxInput from '@arcgis/core/form/elements/inputs/TextBoxInput';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetTextBoxInput } from './textBoxInput';

export async function buildJsTextBoxInputGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

    if (hasValue(dotNetObject.maxLength)) {
        properties.maxLength = dotNetObject.maxLength;
    }
    if (hasValue(dotNetObject.minLength)) {
        properties.minLength = dotNetObject.minLength;
    }
    let jsTextBoxInput = new TextBoxInput(properties);
    
    jsObjectRefs[dotNetObject.id] = jsTextBoxInput;
    arcGisObjectRefs[dotNetObject.id] = jsTextBoxInput;
    
    return jsTextBoxInput;
}


export async function buildDotNetTextBoxInputGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetTextBoxInput: any = {};
    
    if (hasValue(jsObject.maxLength)) {
        dotNetTextBoxInput.maxLength = jsObject.maxLength;
    }
    
    if (hasValue(jsObject.minLength)) {
        dotNetTextBoxInput.minLength = jsObject.minLength;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetTextBoxInput.type = removeCircularReferences(jsObject.type);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetTextBoxInput.id = geoBlazorId;
    }

    return dotNetTextBoxInput;
}

