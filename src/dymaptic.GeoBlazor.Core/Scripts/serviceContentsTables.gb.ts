import {buildDotNetServiceContentsTables} from './serviceContentsTables';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsServiceContentsTablesGenerated(dotNetObject: any): Promise<any> {
    let jsServiceContentsTables: any = {}

    if (hasValue(dotNetObject.capabilities)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedCapabilities} = dotNetObject.capabilities;
        jsServiceContentsTables.capabilities = sanitizedCapabilities;
    }
    if (hasValue(dotNetObject.tableInfos)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedTableInfos} = dotNetObject.tableInfos;
        jsServiceContentsTables.tableInfos = sanitizedTableInfos;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsServiceContentsTables);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsServiceContentsTables;

    let dnInstantiatedObject = await buildDotNetServiceContentsTables(jsServiceContentsTables);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ServiceContentsTables', e);
    }

    return jsServiceContentsTables;
}

export async function buildDotNetServiceContentsTablesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetServiceContentsTables: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.capabilities)) {
        dotNetServiceContentsTables.capabilities = jsObject.capabilities;
    }
    if (hasValue(jsObject.tableInfos)) {
        dotNetServiceContentsTables.tableInfos = jsObject.tableInfos;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetServiceContentsTables.id = k;
                break;
            }
        }
    }

    return dotNetServiceContentsTables;
}

