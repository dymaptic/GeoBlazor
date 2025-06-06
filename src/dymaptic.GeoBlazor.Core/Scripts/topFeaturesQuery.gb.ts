// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import TopFeaturesQuery from '@arcgis/core/rest/support/TopFeaturesQuery';
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetTopFeaturesQuery } from './topFeaturesQuery';

export async function buildJsTopFeaturesQueryGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.geometry)) {
        let { buildJsGeometry } = await import('./geometry');
        properties.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }
    if (hasValue(dotNetObject.outSpatialReference)) {
        let { buildJsSpatialReference } = await import('./spatialReference');
        properties.outSpatialReference = buildJsSpatialReference(dotNetObject.outSpatialReference) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        let { buildJsTimeExtent } = await import('./timeExtent');
        properties.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }

    if (hasValue(dotNetObject.cacheHint)) {
        properties.cacheHint = dotNetObject.cacheHint;
    }
    if (hasValue(dotNetObject.distance)) {
        properties.distance = dotNetObject.distance;
    }
    if (hasValue(dotNetObject.geometryPrecision)) {
        properties.geometryPrecision = dotNetObject.geometryPrecision;
    }
    if (hasValue(dotNetObject.maxAllowableOffset)) {
        properties.maxAllowableOffset = dotNetObject.maxAllowableOffset;
    }
    if (hasValue(dotNetObject.num)) {
        properties.num = dotNetObject.num;
    }
    if (hasValue(dotNetObject.objectIds) && dotNetObject.objectIds.length > 0) {
        properties.objectIds = dotNetObject.objectIds;
    }
    if (hasValue(dotNetObject.orderByFields) && dotNetObject.orderByFields.length > 0) {
        properties.orderByFields = dotNetObject.orderByFields;
    }
    if (hasValue(dotNetObject.outFields) && dotNetObject.outFields.length > 0) {
        properties.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.returnGeometry)) {
        properties.returnGeometry = dotNetObject.returnGeometry;
    }
    if (hasValue(dotNetObject.returnM)) {
        properties.returnM = dotNetObject.returnM;
    }
    if (hasValue(dotNetObject.returnZ)) {
        properties.returnZ = dotNetObject.returnZ;
    }
    if (hasValue(dotNetObject.spatialRelationship)) {
        properties.spatialRelationship = dotNetObject.spatialRelationship;
    }
    if (hasValue(dotNetObject.start)) {
        properties.start = dotNetObject.start;
    }
    if (hasValue(dotNetObject.topFilter)) {
        properties.topFilter = dotNetObject.topFilter;
    }
    if (hasValue(dotNetObject.units)) {
        properties.units = dotNetObject.units;
    }
    if (hasValue(dotNetObject.where)) {
        properties.where = dotNetObject.where;
    }
    let jsTopFeaturesQuery = new TopFeaturesQuery(properties);
    
    jsObjectRefs[dotNetObject.id] = jsTopFeaturesQuery;
    arcGisObjectRefs[dotNetObject.id] = jsTopFeaturesQuery;
    
    return jsTopFeaturesQuery;
}


export async function buildDotNetTopFeaturesQueryGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetTopFeaturesQuery: any = {};
    
    if (hasValue(jsObject.geometry)) {
        let { buildDotNetGeometry } = await import('./geometry');
        dotNetTopFeaturesQuery.geometry = buildDotNetGeometry(jsObject.geometry);
    }
    
    if (hasValue(jsObject.outSpatialReference)) {
        let { buildDotNetSpatialReference } = await import('./spatialReference');
        dotNetTopFeaturesQuery.outSpatialReference = buildDotNetSpatialReference(jsObject.outSpatialReference);
    }
    
    if (hasValue(jsObject.timeExtent)) {
        let { buildDotNetTimeExtent } = await import('./timeExtent');
        dotNetTopFeaturesQuery.timeExtent = buildDotNetTimeExtent(jsObject.timeExtent);
    }
    
    if (hasValue(jsObject.cacheHint)) {
        dotNetTopFeaturesQuery.cacheHint = jsObject.cacheHint;
    }
    
    if (hasValue(jsObject.distance)) {
        dotNetTopFeaturesQuery.distance = jsObject.distance;
    }
    
    if (hasValue(jsObject.geometryPrecision)) {
        dotNetTopFeaturesQuery.geometryPrecision = jsObject.geometryPrecision;
    }
    
    if (hasValue(jsObject.maxAllowableOffset)) {
        dotNetTopFeaturesQuery.maxAllowableOffset = jsObject.maxAllowableOffset;
    }
    
    if (hasValue(jsObject.num)) {
        dotNetTopFeaturesQuery.num = jsObject.num;
    }
    
    if (hasValue(jsObject.objectIds)) {
        dotNetTopFeaturesQuery.objectIds = removeCircularReferences(jsObject.objectIds);
    }
    
    if (hasValue(jsObject.orderByFields)) {
        dotNetTopFeaturesQuery.orderByFields = jsObject.orderByFields;
    }
    
    if (hasValue(jsObject.outFields)) {
        dotNetTopFeaturesQuery.outFields = jsObject.outFields;
    }
    
    if (hasValue(jsObject.returnGeometry)) {
        dotNetTopFeaturesQuery.returnGeometry = jsObject.returnGeometry;
    }
    
    if (hasValue(jsObject.returnM)) {
        dotNetTopFeaturesQuery.returnM = jsObject.returnM;
    }
    
    if (hasValue(jsObject.returnZ)) {
        dotNetTopFeaturesQuery.returnZ = jsObject.returnZ;
    }
    
    if (hasValue(jsObject.spatialRelationship)) {
        dotNetTopFeaturesQuery.spatialRelationship = removeCircularReferences(jsObject.spatialRelationship);
    }
    
    if (hasValue(jsObject.start)) {
        dotNetTopFeaturesQuery.start = jsObject.start;
    }
    
    if (hasValue(jsObject.topFilter)) {
        dotNetTopFeaturesQuery.topFilter = removeCircularReferences(jsObject.topFilter);
    }
    
    if (hasValue(jsObject.units)) {
        dotNetTopFeaturesQuery.units = removeCircularReferences(jsObject.units);
    }
    
    if (hasValue(jsObject.where)) {
        dotNetTopFeaturesQuery.where = jsObject.where;
    }
    

    return dotNetTopFeaturesQuery;
}

