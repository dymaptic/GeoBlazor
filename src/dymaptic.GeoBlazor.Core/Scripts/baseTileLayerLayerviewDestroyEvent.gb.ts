import {buildDotNetBaseTileLayerLayerviewDestroyEvent} from './baseTileLayerLayerviewDestroyEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBaseTileLayerLayerviewDestroyEventGenerated(dotNetObject: any): Promise<any> {
    let jsBaseTileLayerLayerviewDestroyEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsBaseTileLayerLayerviewDestroyEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsBaseTileLayerLayerviewDestroyEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBaseTileLayerLayerviewDestroyEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBaseTileLayerLayerviewDestroyEvent;

    let dnInstantiatedObject = await buildDotNetBaseTileLayerLayerviewDestroyEvent(jsBaseTileLayerLayerviewDestroyEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BaseTileLayerLayerviewDestroyEvent', e);
    }

    return jsBaseTileLayerLayerviewDestroyEvent;
}

export async function buildDotNetBaseTileLayerLayerviewDestroyEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBaseTileLayerLayerviewDestroyEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetBaseTileLayerLayerviewDestroyEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetBaseTileLayerLayerviewDestroyEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBaseTileLayerLayerviewDestroyEvent.id = k;
                break;
            }
        }
    }

    return dotNetBaseTileLayerLayerviewDestroyEvent;
}

