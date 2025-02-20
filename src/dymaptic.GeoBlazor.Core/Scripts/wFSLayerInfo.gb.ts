import {buildDotNetWFSLayerInfo} from './wFSLayerInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsWFSLayerInfoGenerated(dotNetObject: any): Promise<any> {
    let jsWFSLayerInfo: any = {}
    if (hasValue(dotNetObject.extent)) {
        let {buildJsExtent} = await import('./extent');
        jsWFSLayerInfo.extent = buildJsExtent(dotNetObject.extent) as any;
    }
    if (hasValue(dotNetObject.fields)) {
        let {buildJsField} = await import('./field');
        jsWFSLayerInfo.fields = dotNetObject.fields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        let {buildJsSpatialReference} = await import('./spatialReference');
        jsWFSLayerInfo.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference) as any;
    }
    if (hasValue(dotNetObject.wfsCapabilities)) {
        let {buildJsWFSCapabilities} = await import('./wFSCapabilities');
        jsWFSLayerInfo.wfsCapabilities = await buildJsWFSCapabilities(dotNetObject.wfsCapabilities, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.customParameters)) {
        jsWFSLayerInfo.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.geometryType)) {
        jsWFSLayerInfo.geometryType = dotNetObject.geometryType;
    }
    if (hasValue(dotNetObject.name)) {
        jsWFSLayerInfo.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.namespaceUri)) {
        jsWFSLayerInfo.namespaceUri = dotNetObject.namespaceUri;
    }
    if (hasValue(dotNetObject.objectIdField)) {
        jsWFSLayerInfo.objectIdField = dotNetObject.objectIdField;
    }
    if (hasValue(dotNetObject.swapXY)) {
        jsWFSLayerInfo.swapXY = dotNetObject.swapXY;
    }
    if (hasValue(dotNetObject.url)) {
        jsWFSLayerInfo.url = dotNetObject.url;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsWFSLayerInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsWFSLayerInfo;

    let dnInstantiatedObject = await buildDotNetWFSLayerInfo(jsWFSLayerInfo);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WFSLayerInfo', e);
    }

    return jsWFSLayerInfo;
}

export async function buildDotNetWFSLayerInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetWFSLayerInfo: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.extent)) {
        let {buildDotNetExtent} = await import('./extent');
        dotNetWFSLayerInfo.extent = buildDotNetExtent(jsObject.extent);
    }
    if (hasValue(jsObject.fields)) {
        let {buildDotNetField} = await import('./field');
        dotNetWFSLayerInfo.fields = jsObject.fields.map(i => buildDotNetField(i));
    }
    if (hasValue(jsObject.spatialReference)) {
        let {buildDotNetSpatialReference} = await import('./spatialReference');
        dotNetWFSLayerInfo.spatialReference = buildDotNetSpatialReference(jsObject.spatialReference);
    }
    if (hasValue(jsObject.wfsCapabilities)) {
        let {buildDotNetWFSCapabilities} = await import('./wFSCapabilities');
        dotNetWFSLayerInfo.wfsCapabilities = await buildDotNetWFSCapabilities(jsObject.wfsCapabilities);
    }
    if (hasValue(jsObject.customParameters)) {
        dotNetWFSLayerInfo.customParameters = jsObject.customParameters;
    }
    if (hasValue(jsObject.geometryType)) {
        dotNetWFSLayerInfo.geometryType = jsObject.geometryType;
    }
    if (hasValue(jsObject.name)) {
        dotNetWFSLayerInfo.name = jsObject.name;
    }
    if (hasValue(jsObject.namespaceUri)) {
        dotNetWFSLayerInfo.namespaceUri = jsObject.namespaceUri;
    }
    if (hasValue(jsObject.objectIdField)) {
        dotNetWFSLayerInfo.objectIdField = jsObject.objectIdField;
    }
    if (hasValue(jsObject.swapXY)) {
        dotNetWFSLayerInfo.swapXY = jsObject.swapXY;
    }
    if (hasValue(jsObject.url)) {
        dotNetWFSLayerInfo.url = jsObject.url;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetWFSLayerInfo.id = k;
                break;
            }
        }
    }

    return dotNetWFSLayerInfo;
}

