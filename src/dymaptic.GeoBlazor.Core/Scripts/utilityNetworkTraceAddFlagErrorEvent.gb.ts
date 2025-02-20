import {buildDotNetUtilityNetworkTraceAddFlagErrorEvent} from './utilityNetworkTraceAddFlagErrorEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsUtilityNetworkTraceAddFlagErrorEventGenerated(dotNetObject: any): Promise<any> {
    let jsUtilityNetworkTraceAddFlagErrorEvent: any = {}
    if (hasValue(dotNetObject.symbol)) {
        let {buildJsSymbol} = await import('./symbol');
        jsUtilityNetworkTraceAddFlagErrorEvent.symbol = buildJsSymbol(dotNetObject.symbol) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsUtilityNetworkTraceAddFlagErrorEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsUtilityNetworkTraceAddFlagErrorEvent;

    let dnInstantiatedObject = await buildDotNetUtilityNetworkTraceAddFlagErrorEvent(jsUtilityNetworkTraceAddFlagErrorEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for UtilityNetworkTraceAddFlagErrorEvent', e);
    }

    return jsUtilityNetworkTraceAddFlagErrorEvent;
}

export async function buildDotNetUtilityNetworkTraceAddFlagErrorEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetUtilityNetworkTraceAddFlagErrorEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.symbol)) {
        let {buildDotNetSymbol} = await import('./symbol');
        dotNetUtilityNetworkTraceAddFlagErrorEvent.symbol = buildDotNetSymbol(jsObject.symbol);
    }
    if (hasValue(jsObject.type)) {
        dotNetUtilityNetworkTraceAddFlagErrorEvent.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetUtilityNetworkTraceAddFlagErrorEvent.id = k;
                break;
            }
        }
    }

    return dotNetUtilityNetworkTraceAddFlagErrorEvent;
}

