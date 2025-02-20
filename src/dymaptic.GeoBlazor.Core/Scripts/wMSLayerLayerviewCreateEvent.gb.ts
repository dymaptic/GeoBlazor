import {buildDotNetWMSLayerLayerviewCreateEvent} from './wMSLayerLayerviewCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsWMSLayerLayerviewCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsWMSLayerLayerviewCreateEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsWMSLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsWMSLayerLayerviewCreateEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsWMSLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsWMSLayerLayerviewCreateEvent;

    let dnInstantiatedObject = await buildDotNetWMSLayerLayerviewCreateEvent(jsWMSLayerLayerviewCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WMSLayerLayerviewCreateEvent', e);
    }

    return jsWMSLayerLayerviewCreateEvent;
}

export async function buildDotNetWMSLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetWMSLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetWMSLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetWMSLayerLayerviewCreateEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetWMSLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetWMSLayerLayerviewCreateEvent;
}

