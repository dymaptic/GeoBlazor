import {buildDotNetMapImageLayerLayerviewCreateEvent} from './mapImageLayerLayerviewCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsMapImageLayerLayerviewCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsMapImageLayerLayerviewCreateEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsMapImageLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsMapImageLayerLayerviewCreateEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsMapImageLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMapImageLayerLayerviewCreateEvent;

    let dnInstantiatedObject = await buildDotNetMapImageLayerLayerviewCreateEvent(jsMapImageLayerLayerviewCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MapImageLayerLayerviewCreateEvent', e);
    }

    return jsMapImageLayerLayerviewCreateEvent;
}

export async function buildDotNetMapImageLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMapImageLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetMapImageLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetMapImageLayerLayerviewCreateEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMapImageLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetMapImageLayerLayerviewCreateEvent;
}

