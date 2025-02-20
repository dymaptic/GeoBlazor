import {buildDotNetCIMLineCallout} from './cIMLineCallout';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCIMLineCalloutGenerated(dotNetObject: any): Promise<any> {
    let jsCIMLineCallout: any = {}
    if (hasValue(dotNetObject.leaderLineSymbol)) {
        let {buildJsCIMLineSymbol} = await import('./cIMLineSymbol');
        jsCIMLineCallout.leaderLineSymbol = await buildJsCIMLineSymbol(dotNetObject.leaderLineSymbol, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.gap)) {
        jsCIMLineCallout.gap = dotNetObject.gap;
    }
    if (hasValue(dotNetObject.leaderOffset)) {
        jsCIMLineCallout.leaderOffset = dotNetObject.leaderOffset;
    }
    if (hasValue(dotNetObject.leaderTolerance)) {
        jsCIMLineCallout.leaderTolerance = dotNetObject.leaderTolerance;
    }
    if (hasValue(dotNetObject.lineStyle)) {
        jsCIMLineCallout.lineStyle = dotNetObject.lineStyle;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCIMLineCallout);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCIMLineCallout;

    let dnInstantiatedObject = await buildDotNetCIMLineCallout(jsCIMLineCallout);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CIMLineCallout', e);
    }

    return jsCIMLineCallout;
}

export async function buildDotNetCIMLineCalloutGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCIMLineCallout: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.leaderLineSymbol)) {
        let {buildDotNetCIMLineSymbol} = await import('./cIMLineSymbol');
        dotNetCIMLineCallout.leaderLineSymbol = await buildDotNetCIMLineSymbol(jsObject.leaderLineSymbol);
    }
    if (hasValue(jsObject.gap)) {
        dotNetCIMLineCallout.gap = jsObject.gap;
    }
    if (hasValue(jsObject.leaderOffset)) {
        dotNetCIMLineCallout.leaderOffset = jsObject.leaderOffset;
    }
    if (hasValue(jsObject.leaderTolerance)) {
        dotNetCIMLineCallout.leaderTolerance = jsObject.leaderTolerance;
    }
    if (hasValue(jsObject.lineStyle)) {
        dotNetCIMLineCallout.lineStyle = jsObject.lineStyle;
    }
    if (hasValue(jsObject.type)) {
        dotNetCIMLineCallout.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCIMLineCallout.id = k;
                break;
            }
        }
    }

    return dotNetCIMLineCallout;
}

