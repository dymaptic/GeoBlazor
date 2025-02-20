import {buildDotNetTileLayerLayerviewDestroyEvent} from './tileLayerLayerviewDestroyEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsTileLayerLayerviewDestroyEventGenerated(dotNetObject: any): Promise<any> {
    let jsTileLayerLayerviewDestroyEvent: any = {}
    if (hasValue(dotNetObject.layerView)) {
        let {buildJsLayerView} = await import('./layerView');
        jsTileLayerLayerviewDestroyEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.view)) {
        jsTileLayerLayerviewDestroyEvent.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsTileLayerLayerviewDestroyEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsTileLayerLayerviewDestroyEvent;

    let dnInstantiatedObject = await buildDotNetTileLayerLayerviewDestroyEvent(jsTileLayerLayerviewDestroyEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for TileLayerLayerviewDestroyEvent', e);
    }

    return jsTileLayerLayerviewDestroyEvent;
}

export async function buildDotNetTileLayerLayerviewDestroyEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTileLayerLayerviewDestroyEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.layerView)) {
        let {buildDotNetLayerView} = await import('./layerView');
        dotNetTileLayerLayerviewDestroyEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
    }
    if (hasValue(jsObject.view)) {
        dotNetTileLayerLayerviewDestroyEvent.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTileLayerLayerviewDestroyEvent.id = k;
                break;
            }
        }
    }

    return dotNetTileLayerLayerviewDestroyEvent;
}

