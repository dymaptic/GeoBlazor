import {buildDotNetBaseDynamicLayerLayerviewDestroyEvent} from './baseDynamicLayerLayerviewDestroyEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBaseDynamicLayerLayerviewDestroyEventGenerated(dotNetObject: any): Promise<any> {
    let jsBaseDynamicLayerLayerviewDestroyEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsBaseDynamicLayerLayerviewDestroyEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsBaseDynamicLayerLayerviewDestroyEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBaseDynamicLayerLayerviewDestroyEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBaseDynamicLayerLayerviewDestroyEvent;

    let dnInstantiatedObject = await buildDotNetBaseDynamicLayerLayerviewDestroyEvent(jsBaseDynamicLayerLayerviewDestroyEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BaseDynamicLayerLayerviewDestroyEvent', e);
    }

    return jsBaseDynamicLayerLayerviewDestroyEvent;
}

export async function buildDotNetBaseDynamicLayerLayerviewDestroyEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBaseDynamicLayerLayerviewDestroyEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetBaseDynamicLayerLayerviewDestroyEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetBaseDynamicLayerLayerviewDestroyEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBaseDynamicLayerLayerviewDestroyEvent.id = k;
                break;
            }
        }
    }

    return dotNetBaseDynamicLayerLayerviewDestroyEvent;
}

