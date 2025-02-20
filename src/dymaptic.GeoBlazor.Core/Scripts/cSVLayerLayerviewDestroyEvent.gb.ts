import {buildDotNetCSVLayerLayerviewDestroyEvent} from './cSVLayerLayerviewDestroyEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCSVLayerLayerviewDestroyEventGenerated(dotNetObject: any): Promise<any> {
    let jsCSVLayerLayerviewDestroyEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsCSVLayerLayerviewDestroyEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsCSVLayerLayerviewDestroyEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCSVLayerLayerviewDestroyEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayerLayerviewDestroyEvent;

    let dnInstantiatedObject = await buildDotNetCSVLayerLayerviewDestroyEvent(jsCSVLayerLayerviewDestroyEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CSVLayerLayerviewDestroyEvent', e);
    }

    return jsCSVLayerLayerviewDestroyEvent;
}

export async function buildDotNetCSVLayerLayerviewDestroyEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCSVLayerLayerviewDestroyEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetCSVLayerLayerviewDestroyEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetCSVLayerLayerviewDestroyEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCSVLayerLayerviewDestroyEvent.id = k;
                break;
            }
        }
    }

    return dotNetCSVLayerLayerviewDestroyEvent;
}

