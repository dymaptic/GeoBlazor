import {buildDotNetBasemapLayerListTriggerActionEvent} from './basemapLayerListTriggerActionEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBasemapLayerListTriggerActionEventGenerated(dotNetObject: any): Promise<any> {
    let jsBasemapLayerListTriggerActionEvent: any = {}
    if (hasValue(dotNetObject.item)) {
        let {buildJsListItem} = await import('./listItem');
        jsBasemapLayerListTriggerActionEvent.item = await buildJsListItem(dotNetObject.item, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.action)) {
        jsBasemapLayerListTriggerActionEvent.action = dotNetObject.action;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBasemapLayerListTriggerActionEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBasemapLayerListTriggerActionEvent;

    let dnInstantiatedObject = await buildDotNetBasemapLayerListTriggerActionEvent(jsBasemapLayerListTriggerActionEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BasemapLayerListTriggerActionEvent', e);
    }

    return jsBasemapLayerListTriggerActionEvent;
}

export async function buildDotNetBasemapLayerListTriggerActionEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBasemapLayerListTriggerActionEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.item)) {
        let {buildDotNetListItem} = await import('./listItem');
        dotNetBasemapLayerListTriggerActionEvent.item = await buildDotNetListItem(jsObject.item);
    }
    if (hasValue(jsObject.action)) {
        dotNetBasemapLayerListTriggerActionEvent.action = jsObject.action;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBasemapLayerListTriggerActionEvent.id = k;
                break;
            }
        }
    }

    return dotNetBasemapLayerListTriggerActionEvent;
}

