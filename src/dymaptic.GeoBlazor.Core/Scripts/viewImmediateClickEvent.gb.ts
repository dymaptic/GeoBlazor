// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetViewImmediateClickEvent } from './viewImmediateClickEvent';

export async function buildJsViewImmediateClickEventGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsViewImmediateClickEvent: any = {};
    if (hasValue(dotNetObject.mapPoint)) {
        let { buildJsPoint } = await import('./point');
        jsViewImmediateClickEvent.mapPoint = buildJsPoint(dotNetObject.mapPoint) as any;
    }

    if (hasValue(dotNetObject.button)) {
        jsViewImmediateClickEvent.button = dotNetObject.button;
    }
    if (hasValue(dotNetObject.buttons)) {
        jsViewImmediateClickEvent.buttons = dotNetObject.buttons;
    }
    if (hasValue(dotNetObject.native)) {
        jsViewImmediateClickEvent.native = dotNetObject.native;
    }
    if (hasValue(dotNetObject.stopPropagation)) {
        jsViewImmediateClickEvent.stopPropagation = dotNetObject.stopPropagation;
    }
    if (hasValue(dotNetObject.timestamp)) {
        jsViewImmediateClickEvent.timestamp = dotNetObject.timestamp;
    }
    if (hasValue(dotNetObject.x)) {
        jsViewImmediateClickEvent.x = dotNetObject.x;
    }
    if (hasValue(dotNetObject.y)) {
        jsViewImmediateClickEvent.y = dotNetObject.y;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsViewImmediateClickEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsViewImmediateClickEvent;
    
    return jsViewImmediateClickEvent;
}


export async function buildDotNetViewImmediateClickEventGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetViewImmediateClickEvent: any = {};
    
    if (hasValue(jsObject.mapPoint)) {
        let { buildDotNetPoint } = await import('./point');
        dotNetViewImmediateClickEvent.mapPoint = buildDotNetPoint(jsObject.mapPoint);
    }
    
    if (hasValue(jsObject.button)) {
        dotNetViewImmediateClickEvent.button = jsObject.button;
    }
    
    if (hasValue(jsObject.buttons)) {
        dotNetViewImmediateClickEvent.buttons = jsObject.buttons;
    }
    
    if (hasValue(jsObject.native)) {
        dotNetViewImmediateClickEvent.native = jsObject.native;
    }
    
    if (hasValue(jsObject.stopPropagation)) {
        dotNetViewImmediateClickEvent.stopPropagation = jsObject.stopPropagation;
    }
    
    if (hasValue(jsObject.timestamp)) {
        dotNetViewImmediateClickEvent.timestamp = jsObject.timestamp;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetViewImmediateClickEvent.type = jsObject.type;
    }
    
    if (hasValue(jsObject.x)) {
        dotNetViewImmediateClickEvent.x = jsObject.x;
    }
    
    if (hasValue(jsObject.y)) {
        dotNetViewImmediateClickEvent.y = jsObject.y;
    }
    

    return dotNetViewImmediateClickEvent;
}

