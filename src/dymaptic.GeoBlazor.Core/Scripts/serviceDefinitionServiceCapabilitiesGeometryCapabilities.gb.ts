// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities } from './serviceDefinitionServiceCapabilitiesGeometryCapabilities';

export async function buildJsServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsServiceDefinitionServiceCapabilitiesGeometryCapabilities: any = {};

    if (hasValue(dotNetObject.geometryMaxBoundingRectangleSizeX)) {
        jsServiceDefinitionServiceCapabilitiesGeometryCapabilities.geometryMaxBoundingRectangleSizeX = dotNetObject.geometryMaxBoundingRectangleSizeX;
    }
    if (hasValue(dotNetObject.geometryMaxBoundingRectangleSizeY)) {
        jsServiceDefinitionServiceCapabilitiesGeometryCapabilities.geometryMaxBoundingRectangleSizeY = dotNetObject.geometryMaxBoundingRectangleSizeY;
    }
    if (hasValue(dotNetObject.supportedGeometryTypes) && dotNetObject.supportedGeometryTypes.length > 0) {
        jsServiceDefinitionServiceCapabilitiesGeometryCapabilities.supportedGeometryTypes = dotNetObject.supportedGeometryTypes;
    }
    if (hasValue(dotNetObject.supportsMValues)) {
        jsServiceDefinitionServiceCapabilitiesGeometryCapabilities.supportsMValues = dotNetObject.supportsMValues;
    }
    if (hasValue(dotNetObject.supportsZValues)) {
        jsServiceDefinitionServiceCapabilitiesGeometryCapabilities.supportsZValues = dotNetObject.supportsZValues;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsServiceDefinitionServiceCapabilitiesGeometryCapabilities);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsServiceDefinitionServiceCapabilitiesGeometryCapabilities;
    
    return jsServiceDefinitionServiceCapabilitiesGeometryCapabilities;
}


export async function buildDotNetServiceDefinitionServiceCapabilitiesGeometryCapabilitiesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities: any = {};
    
    if (hasValue(jsObject.geometryMaxBoundingRectangleSizeX)) {
        dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities.geometryMaxBoundingRectangleSizeX = jsObject.geometryMaxBoundingRectangleSizeX;
    }
    
    if (hasValue(jsObject.geometryMaxBoundingRectangleSizeY)) {
        dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities.geometryMaxBoundingRectangleSizeY = jsObject.geometryMaxBoundingRectangleSizeY;
    }
    
    if (hasValue(jsObject.supportedGeometryTypes)) {
        dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities.supportedGeometryTypes = jsObject.supportedGeometryTypes;
    }
    
    if (hasValue(jsObject.supportsMValues)) {
        dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities.supportsMValues = jsObject.supportsMValues;
    }
    
    if (hasValue(jsObject.supportsZValues)) {
        dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities.supportsZValues = jsObject.supportsZValues;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities.id = geoBlazorId;
    }

    return dotNetServiceDefinitionServiceCapabilitiesGeometryCapabilities;
}

