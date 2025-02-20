import {buildDotNetWebTileLayerLayerviewDestroyEvent} from './webTileLayerLayerviewDestroyEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsWebTileLayerLayerviewDestroyEventGenerated(dotNetObject: any): Promise<any> {
    let jsWebTileLayerLayerviewDestroyEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsWebTileLayerLayerviewDestroyEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsWebTileLayerLayerviewDestroyEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsWebTileLayerLayerviewDestroyEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsWebTileLayerLayerviewDestroyEvent;

    let dnInstantiatedObject = await buildDotNetWebTileLayerLayerviewDestroyEvent(jsWebTileLayerLayerviewDestroyEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WebTileLayerLayerviewDestroyEvent', e);
    }

    return jsWebTileLayerLayerviewDestroyEvent;
}

export async function buildDotNetWebTileLayerLayerviewDestroyEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetWebTileLayerLayerviewDestroyEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetWebTileLayerLayerviewDestroyEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetWebTileLayerLayerviewDestroyEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetWebTileLayerLayerviewDestroyEvent.id = k;
                break;
            }
        }
    }

    return dotNetWebTileLayerLayerviewDestroyEvent;
}

