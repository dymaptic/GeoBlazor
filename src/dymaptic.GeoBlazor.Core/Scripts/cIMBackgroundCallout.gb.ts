import {buildDotNetCIMBackgroundCallout} from './cIMBackgroundCallout';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCIMBackgroundCalloutGenerated(dotNetObject: any): Promise<any> {
    let jsCIMBackgroundCallout: any = {}
    if (hasValue(dotNetObject.backgroundSymbol)) {
        let {buildJsCIMPolygonSymbol} = await import('./cIMPolygonSymbol');
        jsCIMBackgroundCallout.backgroundSymbol = await buildJsCIMPolygonSymbol(dotNetObject.backgroundSymbol, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCIMBackgroundCallout);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCIMBackgroundCallout;

    let dnInstantiatedObject = await buildDotNetCIMBackgroundCallout(jsCIMBackgroundCallout);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CIMBackgroundCallout', e);
    }

    return jsCIMBackgroundCallout;
}

export async function buildDotNetCIMBackgroundCalloutGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCIMBackgroundCallout: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.backgroundSymbol)) {
        let {buildDotNetCIMPolygonSymbol} = await import('./cIMPolygonSymbol');
        dotNetCIMBackgroundCallout.backgroundSymbol = await buildDotNetCIMPolygonSymbol(jsObject.backgroundSymbol);
    }
    if (hasValue(jsObject.type)) {
        dotNetCIMBackgroundCallout.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCIMBackgroundCallout.id = k;
                break;
            }
        }
    }

    return dotNetCIMBackgroundCallout;
}

