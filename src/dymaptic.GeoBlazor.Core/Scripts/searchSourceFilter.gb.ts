import {buildDotNetSearchSourceFilter} from './searchSourceFilter';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSearchSourceFilterGenerated(dotNetObject: any): Promise<any> {
    let jsSearchSourceFilter: any = {}
    if (hasValue(dotNetObject.geometry)) {
        let {buildJsGeometry} = await import('./geometry');
        jsSearchSourceFilter.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }

    if (hasValue(dotNetObject.where)) {
        jsSearchSourceFilter.where = dotNetObject.where;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSearchSourceFilter);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSearchSourceFilter;

    let dnInstantiatedObject = await buildDotNetSearchSourceFilter(jsSearchSourceFilter);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SearchSourceFilter', e);
    }

    return jsSearchSourceFilter;
}

export async function buildDotNetSearchSourceFilterGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSearchSourceFilter: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.geometry)) {
        let {buildDotNetGeometry} = await import('./geometry');
        dotNetSearchSourceFilter.geometry = buildDotNetGeometry(jsObject.geometry);
    }
    if (hasValue(jsObject.where)) {
        dotNetSearchSourceFilter.where = jsObject.where;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSearchSourceFilter.id = k;
                break;
            }
        }
    }

    return dotNetSearchSourceFilter;
}

