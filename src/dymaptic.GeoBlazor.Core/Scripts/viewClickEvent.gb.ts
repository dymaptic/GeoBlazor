// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetViewClickEvent } from './viewClickEvent';

export async function buildJsViewClickEventGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsViewClickEvent: any = {};
    if (hasValue(dotNetObject.mapPoint)) {
        let { buildJsPoint } = await import('./point');
        jsViewClickEvent.mapPoint = buildJsPoint(dotNetObject.mapPoint) as any;
    }

    if (hasValue(dotNetObject.button)) {
        jsViewClickEvent.button = dotNetObject.button;
    }
    if (hasValue(dotNetObject.buttons)) {
        jsViewClickEvent.buttons = dotNetObject.buttons;
    }
    if (hasValue(dotNetObject.native)) {
        jsViewClickEvent.native = dotNetObject.native;
    }
    if (hasValue(dotNetObject.stopPropagation)) {
        jsViewClickEvent.stopPropagation = dotNetObject.stopPropagation;
    }
    if (hasValue(dotNetObject.timestamp)) {
        jsViewClickEvent.timestamp = dotNetObject.timestamp;
    }
    if (hasValue(dotNetObject.x)) {
        jsViewClickEvent.x = dotNetObject.x;
    }
    if (hasValue(dotNetObject.y)) {
        jsViewClickEvent.y = dotNetObject.y;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsViewClickEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsViewClickEvent;
    
    return jsViewClickEvent;
}


export async function buildDotNetViewClickEventGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetViewClickEvent: any = {};
    
    if (hasValue(jsObject.mapPoint)) {
        let { buildDotNetPoint } = await import('./point');
        dotNetViewClickEvent.mapPoint = buildDotNetPoint(jsObject.mapPoint);
    }
    
    if (hasValue(jsObject.button)) {
        dotNetViewClickEvent.button = jsObject.button;
    }
    
    if (hasValue(jsObject.buttons)) {
        dotNetViewClickEvent.buttons = jsObject.buttons;
    }
    
    if (hasValue(jsObject.native)) {
        dotNetViewClickEvent.native = jsObject.native;
    }
    
    if (hasValue(jsObject.stopPropagation)) {
        dotNetViewClickEvent.stopPropagation = jsObject.stopPropagation;
    }
    
    if (hasValue(jsObject.timestamp)) {
        dotNetViewClickEvent.timestamp = jsObject.timestamp;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetViewClickEvent.type = jsObject.type;
    }
    
    if (hasValue(jsObject.x)) {
        dotNetViewClickEvent.x = jsObject.x;
    }
    
    if (hasValue(jsObject.y)) {
        dotNetViewClickEvent.y = jsObject.y;
    }
    

    return dotNetViewClickEvent;
}

