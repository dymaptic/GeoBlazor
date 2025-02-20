import {buildDotNetCSVLayerLayerviewCreateEvent} from './cSVLayerLayerviewCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCSVLayerLayerviewCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsCSVLayerLayerviewCreateEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsCSVLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsCSVLayerLayerviewCreateEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCSVLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayerLayerviewCreateEvent;

    let dnInstantiatedObject = await buildDotNetCSVLayerLayerviewCreateEvent(jsCSVLayerLayerviewCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CSVLayerLayerviewCreateEvent', e);
    }

    return jsCSVLayerLayerviewCreateEvent;
}

export async function buildDotNetCSVLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCSVLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetCSVLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetCSVLayerLayerviewCreateEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCSVLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetCSVLayerLayerviewCreateEvent;
}

