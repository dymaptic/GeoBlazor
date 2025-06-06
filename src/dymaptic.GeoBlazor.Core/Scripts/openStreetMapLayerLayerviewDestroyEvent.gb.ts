// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetOpenStreetMapLayerLayerviewDestroyEvent } from './openStreetMapLayerLayerviewDestroyEvent';

export async function buildJsOpenStreetMapLayerLayerviewDestroyEventGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsOpenStreetMapLayerLayerviewDestroyEvent: any = {};
    if (hasValue(viewId)) {
        jsOpenStreetMapLayerLayerviewDestroyEvent.view = arcGisObjectRefs[viewId!];
    }
    if (hasValue(dotNetObject.layerView)) {
        let { buildJsLayerView } = await import('./layerView');
        jsOpenStreetMapLayerLayerviewDestroyEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    
    let jsObjectRef = DotNet.createJSObjectReference(jsOpenStreetMapLayerLayerviewDestroyEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsOpenStreetMapLayerLayerviewDestroyEvent;
    
    let dnInstantiatedObject = await buildDotNetOpenStreetMapLayerLayerviewDestroyEvent(jsOpenStreetMapLayerLayerviewDestroyEvent);
    
    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for OpenStreetMapLayerLayerviewDestroyEvent', e);
    }
    
    return jsOpenStreetMapLayerLayerviewDestroyEvent;
}

export async function buildDotNetOpenStreetMapLayerLayerviewDestroyEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetOpenStreetMapLayerLayerviewDestroyEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.layerView)) {
            let { buildDotNetLayerView } = await import('./layerView');
            dotNetOpenStreetMapLayerLayerviewDestroyEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
        }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetOpenStreetMapLayerLayerviewDestroyEvent.id = k;
                break;
            }
        }
    }

    return dotNetOpenStreetMapLayerLayerviewDestroyEvent;
}

