import {buildDotNetBingMapsLayerLayerviewCreateEvent} from './bingMapsLayerLayerviewCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBingMapsLayerLayerviewCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsBingMapsLayerLayerviewCreateEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsBingMapsLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsBingMapsLayerLayerviewCreateEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBingMapsLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBingMapsLayerLayerviewCreateEvent;

    let dnInstantiatedObject = await buildDotNetBingMapsLayerLayerviewCreateEvent(jsBingMapsLayerLayerviewCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BingMapsLayerLayerviewCreateEvent', e);
    }

    return jsBingMapsLayerLayerviewCreateEvent;
}

export async function buildDotNetBingMapsLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBingMapsLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetBingMapsLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetBingMapsLayerLayerviewCreateEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBingMapsLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetBingMapsLayerLayerviewCreateEvent;
}

