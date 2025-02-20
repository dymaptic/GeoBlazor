import {buildDotNetSubtypeGroupLayerLayerviewCreateEvent} from './subtypeGroupLayerLayerviewCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSubtypeGroupLayerLayerviewCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsSubtypeGroupLayerLayerviewCreateEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsSubtypeGroupLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsSubtypeGroupLayerLayerviewCreateEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSubtypeGroupLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSubtypeGroupLayerLayerviewCreateEvent;

    let dnInstantiatedObject = await buildDotNetSubtypeGroupLayerLayerviewCreateEvent(jsSubtypeGroupLayerLayerviewCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SubtypeGroupLayerLayerviewCreateEvent', e);
    }

    return jsSubtypeGroupLayerLayerviewCreateEvent;
}

export async function buildDotNetSubtypeGroupLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSubtypeGroupLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetSubtypeGroupLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetSubtypeGroupLayerLayerviewCreateEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSubtypeGroupLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetSubtypeGroupLayerLayerviewCreateEvent;
}

