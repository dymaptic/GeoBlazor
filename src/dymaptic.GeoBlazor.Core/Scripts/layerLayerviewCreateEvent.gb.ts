// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetLayerLayerviewCreateEvent } from './layerLayerviewCreateEvent';

export async function buildJsLayerLayerviewCreateEventGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsLayerLayerviewCreateEvent: any = {};
    if (hasValue(viewId)) {
        jsLayerLayerviewCreateEvent.view = arcGisObjectRefs[viewId!];
    }
    if (hasValue(dotNetObject.layerView)) {
        let { buildJsLayerView } = await import('./layerView');
        jsLayerLayerviewCreateEvent.layerView = await buildJsLayerView(dotNetObject.layerView, layerId, viewId) as any;
    }

    
    let jsObjectRef = DotNet.createJSObjectReference(jsLayerLayerviewCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLayerLayerviewCreateEvent;
    
    let dnInstantiatedObject = await buildDotNetLayerLayerviewCreateEvent(jsLayerLayerviewCreateEvent);
    
    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LayerLayerviewCreateEvent', e);
    }
    
    return jsLayerLayerviewCreateEvent;
}

export async function buildDotNetLayerLayerviewCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetLayerLayerviewCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.layerView)) {
            let { buildDotNetLayerView } = await import('./layerView');
            dotNetLayerLayerviewCreateEvent.layerView = await buildDotNetLayerView(jsObject.layerView);
        }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLayerLayerviewCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetLayerLayerviewCreateEvent;
}

