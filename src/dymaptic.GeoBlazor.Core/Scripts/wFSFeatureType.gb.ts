import {buildDotNetWFSFeatureType} from './wFSFeatureType';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsWFSFeatureTypeGenerated(dotNetObject: any): Promise<any> {
    let jsWFSFeatureType: any = {}
    if (hasValue(dotNetObject.extent)) {
        let {buildJsExtent} = await import('./extent');
        jsWFSFeatureType.extent = buildJsExtent(dotNetObject.extent) as any;
    }

    if (hasValue(dotNetObject.defaultSpatialReference)) {
        jsWFSFeatureType.defaultSpatialReference = dotNetObject.defaultSpatialReference;
    }
    if (hasValue(dotNetObject.description)) {
        jsWFSFeatureType.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.name)) {
        jsWFSFeatureType.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.namespacePrefix)) {
        jsWFSFeatureType.namespacePrefix = dotNetObject.namespacePrefix;
    }
    if (hasValue(dotNetObject.namespaceUri)) {
        jsWFSFeatureType.namespaceUri = dotNetObject.namespaceUri;
    }
    if (hasValue(dotNetObject.supportedSpatialReferences)) {
        jsWFSFeatureType.supportedSpatialReferences = dotNetObject.supportedSpatialReferences;
    }
    if (hasValue(dotNetObject.title)) {
        jsWFSFeatureType.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.typeName)) {
        jsWFSFeatureType.typeName = dotNetObject.typeName;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsWFSFeatureType);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsWFSFeatureType;

    let dnInstantiatedObject = await buildDotNetWFSFeatureType(jsWFSFeatureType);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WFSFeatureType', e);
    }

    return jsWFSFeatureType;
}

export async function buildDotNetWFSFeatureTypeGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetWFSFeatureType: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.extent)) {
        let {buildDotNetExtent} = await import('./extent');
        dotNetWFSFeatureType.extent = buildDotNetExtent(jsObject.extent);
    }
    if (hasValue(jsObject.defaultSpatialReference)) {
        dotNetWFSFeatureType.defaultSpatialReference = jsObject.defaultSpatialReference;
    }
    if (hasValue(jsObject.description)) {
        dotNetWFSFeatureType.description = jsObject.description;
    }
    if (hasValue(jsObject.name)) {
        dotNetWFSFeatureType.name = jsObject.name;
    }
    if (hasValue(jsObject.namespacePrefix)) {
        dotNetWFSFeatureType.namespacePrefix = jsObject.namespacePrefix;
    }
    if (hasValue(jsObject.namespaceUri)) {
        dotNetWFSFeatureType.namespaceUri = jsObject.namespaceUri;
    }
    if (hasValue(jsObject.supportedSpatialReferences)) {
        dotNetWFSFeatureType.supportedSpatialReferences = jsObject.supportedSpatialReferences;
    }
    if (hasValue(jsObject.title)) {
        dotNetWFSFeatureType.title = jsObject.title;
    }
    if (hasValue(jsObject.typeName)) {
        dotNetWFSFeatureType.typeName = jsObject.typeName;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetWFSFeatureType.id = k;
                break;
            }
        }
    }

    return dotNetWFSFeatureType;
}

