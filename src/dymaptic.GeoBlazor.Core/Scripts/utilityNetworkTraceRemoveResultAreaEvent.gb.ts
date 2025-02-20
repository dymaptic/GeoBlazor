import {buildDotNetUtilityNetworkTraceRemoveResultAreaEvent} from './utilityNetworkTraceRemoveResultAreaEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsUtilityNetworkTraceRemoveResultAreaEventGenerated(dotNetObject: any): Promise<any> {
    let jsUtilityNetworkTraceRemoveResultAreaEvent: any = {}
    if (hasValue(dotNetObject.graphic)) {
        let {buildJsGraphic} = await import('./graphic');
        jsUtilityNetworkTraceRemoveResultAreaEvent.graphic = buildJsGraphic(dotNetObject.graphic) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsUtilityNetworkTraceRemoveResultAreaEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsUtilityNetworkTraceRemoveResultAreaEvent;

    let dnInstantiatedObject = await buildDotNetUtilityNetworkTraceRemoveResultAreaEvent(jsUtilityNetworkTraceRemoveResultAreaEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for UtilityNetworkTraceRemoveResultAreaEvent', e);
    }

    return jsUtilityNetworkTraceRemoveResultAreaEvent;
}

export async function buildDotNetUtilityNetworkTraceRemoveResultAreaEventGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetUtilityNetworkTraceRemoveResultAreaEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.graphic)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetUtilityNetworkTraceRemoveResultAreaEvent.graphic = buildDotNetGraphic(jsObject.graphic, layerId, viewId);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetUtilityNetworkTraceRemoveResultAreaEvent.id = k;
                break;
            }
        }
    }

    return dotNetUtilityNetworkTraceRemoveResultAreaEvent;
}

