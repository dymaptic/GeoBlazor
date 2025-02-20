import {buildDotNetOGCFeatureLayerLayerviewCreateEvent} from './oGCFeatureLayerLayerviewCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsOGCFeatureLayerLayerviewCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsOGCFeatureLayerLayerviewCreateEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsOGCFeatureLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsOGCFeatureLayerLayerviewCreateEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsOGCFeatureLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsOGCFeatureLayerLayerviewCreateEvent;

    let dnInstantiatedObject = await buildDotNetOGCFeatureLayerLayerviewCreateEvent(jsOGCFeatureLayerLayerviewCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for OGCFeatureLayerLayerviewCreateEvent', e);
    }

    return jsOGCFeatureLayerLayerviewCreateEvent;
}

export async function buildDotNetOGCFeatureLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetOGCFeatureLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetOGCFeatureLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetOGCFeatureLayerLayerviewCreateEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetOGCFeatureLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetOGCFeatureLayerLayerviewCreateEvent;
}

