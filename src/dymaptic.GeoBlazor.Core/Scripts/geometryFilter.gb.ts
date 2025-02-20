import {buildDotNetGeometryFilter} from './geometryFilter';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsGeometryFilterGenerated(dotNetObject: any): Promise<any> {
    let jsGeometryFilter: any = {}
    if (hasValue(dotNetObject.geometry)) {
        let {buildJsGeometry} = await import('./geometry');
        jsGeometryFilter.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsGeometryFilter);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsGeometryFilter;

    let dnInstantiatedObject = await buildDotNetGeometryFilter(jsGeometryFilter);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for GeometryFilter', e);
    }

    return jsGeometryFilter;
}

export async function buildDotNetGeometryFilterGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetGeometryFilter: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.geometry)) {
        let {buildDotNetGeometry} = await import('./geometry');
        dotNetGeometryFilter.geometry = buildDotNetGeometry(jsObject.geometry);
    }
    if (hasValue(jsObject.type)) {
        dotNetGeometryFilter.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetGeometryFilter.id = k;
                break;
            }
        }
    }

    return dotNetGeometryFilter;
}

