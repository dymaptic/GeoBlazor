// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetVisibleElements } from './visibleElements';

export async function buildJsVisibleElementsGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsVisibleElements: any = {};

    if (hasValue(dotNetObject.area)) {
        jsVisibleElements.area = dotNetObject.area;
    }
    if (hasValue(dotNetObject.coordinates)) {
        jsVisibleElements.coordinates = dotNetObject.coordinates;
    }
    if (hasValue(dotNetObject.direction)) {
        jsVisibleElements.direction = dotNetObject.direction;
    }
    if (hasValue(dotNetObject.distance)) {
        jsVisibleElements.distance = dotNetObject.distance;
    }
    if (hasValue(dotNetObject.elevation)) {
        jsVisibleElements.elevation = dotNetObject.elevation;
    }
    if (hasValue(dotNetObject.header)) {
        jsVisibleElements.header = dotNetObject.header;
    }
    if (hasValue(dotNetObject.helpMessage)) {
        jsVisibleElements.helpMessage = dotNetObject.helpMessage;
    }
    if (hasValue(dotNetObject.orientation)) {
        jsVisibleElements.orientation = dotNetObject.orientation;
    }
    if (hasValue(dotNetObject.radius)) {
        jsVisibleElements.radius = dotNetObject.radius;
    }
    if (hasValue(dotNetObject.rotation)) {
        jsVisibleElements.rotation = dotNetObject.rotation;
    }
    if (hasValue(dotNetObject.scale)) {
        jsVisibleElements.scale = dotNetObject.scale;
    }
    if (hasValue(dotNetObject.size)) {
        jsVisibleElements.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.totalLength)) {
        jsVisibleElements.totalLength = dotNetObject.totalLength;
    }
    
    jsObjectRefs[dotNetObject.id] = jsVisibleElements;
    arcGisObjectRefs[dotNetObject.id] = jsVisibleElements;
    
    return jsVisibleElements;
}


export async function buildDotNetVisibleElementsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetVisibleElements: any = {};
    
    if (hasValue(jsObject.area)) {
        dotNetVisibleElements.area = jsObject.area;
    }
    
    if (hasValue(jsObject.coordinates)) {
        dotNetVisibleElements.coordinates = jsObject.coordinates;
    }
    
    if (hasValue(jsObject.direction)) {
        dotNetVisibleElements.direction = jsObject.direction;
    }
    
    if (hasValue(jsObject.distance)) {
        dotNetVisibleElements.distance = jsObject.distance;
    }
    
    if (hasValue(jsObject.elevation)) {
        dotNetVisibleElements.elevation = jsObject.elevation;
    }
    
    if (hasValue(jsObject.header)) {
        dotNetVisibleElements.header = jsObject.header;
    }
    
    if (hasValue(jsObject.helpMessage)) {
        dotNetVisibleElements.helpMessage = jsObject.helpMessage;
    }
    
    if (hasValue(jsObject.orientation)) {
        dotNetVisibleElements.orientation = jsObject.orientation;
    }
    
    if (hasValue(jsObject.radius)) {
        dotNetVisibleElements.radius = jsObject.radius;
    }
    
    if (hasValue(jsObject.rotation)) {
        dotNetVisibleElements.rotation = jsObject.rotation;
    }
    
    if (hasValue(jsObject.scale)) {
        dotNetVisibleElements.scale = jsObject.scale;
    }
    
    if (hasValue(jsObject.size)) {
        dotNetVisibleElements.size = jsObject.size;
    }
    
    if (hasValue(jsObject.totalLength)) {
        dotNetVisibleElements.totalLength = jsObject.totalLength;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetVisibleElements.id = geoBlazorId;
    }

    return dotNetVisibleElements;
}

