// override generated code in this file
import {arcGisObjectRefs, dotNetRefs, hasValue, jsObjectRefs, removeCircularReferences} from "./geoBlazorCore";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetTimeExtent, buildJsTimeExtent} from "./timeExtent";
import Query from "@arcgis/core/rest/support/Query";
import {DotNetQuery} from "./definitions";

export function buildJsQuery(dotNetQuery: any): Query | undefined {
    if (!hasValue(dotNetQuery)) {
        return undefined;
    }
    
    let jsObject: any = {};
    let currentQuery: boolean = false;
    
    if (jsObjectRefs.hasOwnProperty(dotNetQuery.id)) {
        jsObject = jsObjectRefs[dotNetQuery.id];
        currentQuery = true;
    }

    if (hasValue(dotNetQuery.geometry)) {
        jsObject.geometry = buildJsGeometry(dotNetQuery.geometry) as any;
    }
    if (hasValue(dotNetQuery.outSpatialReference)) {
        jsObject.outSpatialReference = buildJsSpatialReference(dotNetQuery.outSpatialReference) as any;
    }
    if (hasValue(dotNetQuery.pixelSize)) {
        jsObject.pixelSize = buildJsPoint(dotNetQuery.pixelSize) as any;
    }
    if (hasValue(dotNetQuery.timeExtent)) {
        jsObject.timeExtent = buildJsTimeExtent(dotNetQuery.timeExtent) as any;
    }

    if (hasValue(dotNetQuery.aggregateIds) && dotNetQuery.aggregateIds.length > 0) {
        jsObject.aggregateIds = dotNetQuery.aggregateIds;
    }
    if (hasValue(dotNetQuery.cacheHint)) {
        jsObject.cacheHint = dotNetQuery.cacheHint;
    }
    if (hasValue(dotNetQuery.datumTransformation)) {
        jsObject.datumTransformation = dotNetQuery.datumTransformation;
    }
    if (hasValue(dotNetQuery.distance)) {
        jsObject.distance = dotNetQuery.distance;
    }
    if (hasValue(dotNetQuery.gdbVersion)) {
        jsObject.gdbVersion = dotNetQuery.gdbVersion;
    }
    if (hasValue(dotNetQuery.geometryPrecision)) {
        jsObject.geometryPrecision = dotNetQuery.geometryPrecision;
    }
    if (hasValue(dotNetQuery.groupByFieldsForStatistics) && dotNetQuery.groupByFieldsForStatistics.length > 0) {
        jsObject.groupByFieldsForStatistics = dotNetQuery.groupByFieldsForStatistics;
    }
    if (hasValue(dotNetQuery.having)) {
        jsObject.having = dotNetQuery.having;
    }
    if (hasValue(dotNetQuery.historicMoment)) {
        jsObject.historicMoment = dotNetQuery.historicMoment;
    }
    if (hasValue(dotNetQuery.maxAllowableOffset)) {
        jsObject.maxAllowableOffset = dotNetQuery.maxAllowableOffset;
    }
    if (hasValue(dotNetQuery.maxRecordCountFactor)) {
        jsObject.maxRecordCountFactor = dotNetQuery.maxRecordCountFactor;
    }
    if (hasValue(dotNetQuery.multipatchOption)) {
        jsObject.multipatchOption = dotNetQuery.multipatchOption;
    }
    if (hasValue(dotNetQuery.num)) {
        jsObject.num = dotNetQuery.num;
    }
    if (hasValue(dotNetQuery.objectIds) && dotNetQuery.objectIds.length > 0) {
        jsObject.objectIds = dotNetQuery.objectIds;
    }
    if (hasValue(dotNetQuery.orderByFields) && dotNetQuery.orderByFields.length > 0) {
        jsObject.orderByFields = dotNetQuery.orderByFields;
    }
    if (hasValue(dotNetQuery.outFields) && dotNetQuery.outFields.length > 0) {
        jsObject.outFields = dotNetQuery.outFields;
    }
    if (hasValue(dotNetQuery.outStatistics) && dotNetQuery.outStatistics.length > 0) {
        jsObject.outStatistics = dotNetQuery.outStatistics;
    }
    if (hasValue(dotNetQuery.parameterValues)) {
        jsObject.parameterValues = dotNetQuery.parameterValues;
    }
    if (hasValue(dotNetQuery.quantizationParameters)) {
        jsObject.quantizationParameters = dotNetQuery.quantizationParameters;
    }
    if (hasValue(dotNetQuery.rangeValues) && dotNetQuery.rangeValues.length > 0) {
        jsObject.rangeValues = dotNetQuery.rangeValues;
    }
    if (hasValue(dotNetQuery.relationParameter)) {
        jsObject.relationParameter = dotNetQuery.relationParameter;
    }
    if (hasValue(dotNetQuery.returnCentroid)) {
        jsObject.returnCentroid = dotNetQuery.returnCentroid;
    }
    if (hasValue(dotNetQuery.returnDistinctValues)) {
        jsObject.returnDistinctValues = dotNetQuery.returnDistinctValues;
    }
    if (hasValue(dotNetQuery.returnExceededLimitFeatures)) {
        jsObject.returnExceededLimitFeatures = dotNetQuery.returnExceededLimitFeatures;
    }
    if (hasValue(dotNetQuery.returnGeometry)) {
        jsObject.returnGeometry = dotNetQuery.returnGeometry;
    }
    if (hasValue(dotNetQuery.returnM)) {
        jsObject.returnM = dotNetQuery.returnM;
    }
    if (hasValue(dotNetQuery.returnQueryGeometry)) {
        jsObject.returnQueryGeometry = dotNetQuery.returnQueryGeometry;
    }
    if (hasValue(dotNetQuery.returnZ)) {
        jsObject.returnZ = dotNetQuery.returnZ;
    }
    if (hasValue(dotNetQuery.spatialRelationship)) {
        jsObject.spatialRelationship = dotNetQuery.spatialRelationship;
    }
    if (hasValue(dotNetQuery.sqlFormat)) {
        jsObject.sqlFormat = dotNetQuery.sqlFormat;
    }
    if (hasValue(dotNetQuery.start)) {
        jsObject.start = dotNetQuery.start;
    }
    if (hasValue(dotNetQuery.text)) {
        jsObject.text = dotNetQuery.text;
    }
    if (hasValue(dotNetQuery.units)) {
        jsObject.units = dotNetQuery.units;
    }
    if (hasValue(dotNetQuery.where)) {
        jsObject.where = dotNetQuery.where;
    }
    return currentQuery ? jsObject : new Query(jsObject);
}

export async function buildDotNetQuery(jsQuery: any, viewId: string | null): Promise<DotNetQuery> {
    let dotNetQuery: any = {};

    if (hasValue(jsQuery.geometry)) {
        dotNetQuery.geometry = buildDotNetGeometry(jsQuery.geometry);
    }

    if (hasValue(jsQuery.outSpatialReference)) {
        dotNetQuery.outSpatialReference = buildDotNetSpatialReference(jsQuery.outSpatialReference);
    }

    if (hasValue(jsQuery.pixelSize)) {
        dotNetQuery.pixelSize = buildDotNetPoint(jsQuery.pixelSize);
    }

    if (hasValue(jsQuery.timeExtent)) {
        dotNetQuery.timeExtent = buildDotNetTimeExtent(jsQuery.timeExtent);
    }

    if (hasValue(jsQuery.aggregateIds)) {
        dotNetQuery.aggregateIds = jsQuery.aggregateIds;
    }

    if (hasValue(jsQuery.cacheHint)) {
        dotNetQuery.cacheHint = jsQuery.cacheHint;
    }

    if (hasValue(jsQuery.datumTransformation)) {
        dotNetQuery.datumTransformation = removeCircularReferences(jsQuery.datumTransformation);
    }

    if (hasValue(jsQuery.distance)) {
        dotNetQuery.distance = jsQuery.distance;
    }

    if (hasValue(jsQuery.gdbVersion)) {
        dotNetQuery.gdbVersion = jsQuery.gdbVersion;
    }

    if (hasValue(jsQuery.geometryPrecision)) {
        dotNetQuery.geometryPrecision = jsQuery.geometryPrecision;
    }

    if (hasValue(jsQuery.groupByFieldsForStatistics)) {
        dotNetQuery.groupByFieldsForStatistics = jsQuery.groupByFieldsForStatistics;
    }

    if (hasValue(jsQuery.having)) {
        dotNetQuery.having = jsQuery.having;
    }

    if (hasValue(jsQuery.historicMoment)) {
        dotNetQuery.historicMoment = jsQuery.historicMoment;
    }

    if (hasValue(jsQuery.maxAllowableOffset)) {
        dotNetQuery.maxAllowableOffset = jsQuery.maxAllowableOffset;
    }

    if (hasValue(jsQuery.maxRecordCountFactor)) {
        dotNetQuery.maxRecordCountFactor = jsQuery.maxRecordCountFactor;
    }

    if (hasValue(jsQuery.multipatchOption)) {
        dotNetQuery.multipatchOption = jsQuery.multipatchOption;
    }

    if (hasValue(jsQuery.num)) {
        dotNetQuery.num = jsQuery.num;
    }

    if (hasValue(jsQuery.objectIds)) {
        dotNetQuery.objectIds = removeCircularReferences(jsQuery.objectIds);
    }

    if (hasValue(jsQuery.orderByFields)) {
        dotNetQuery.orderByFields = jsQuery.orderByFields;
    }

    if (hasValue(jsQuery.outFields)) {
        dotNetQuery.outFields = jsQuery.outFields;
    }

    if (hasValue(jsQuery.outStatistics)) {
        dotNetQuery.outStatistics = removeCircularReferences(jsQuery.outStatistics);
    }

    if (hasValue(jsQuery.parameterValues)) {
        dotNetQuery.parameterValues = removeCircularReferences(jsQuery.parameterValues);
    }

    if (hasValue(jsQuery.quantizationParameters)) {
        dotNetQuery.quantizationParameters = removeCircularReferences(jsQuery.quantizationParameters);
    }

    if (hasValue(jsQuery.rangeValues)) {
        dotNetQuery.rangeValues = removeCircularReferences(jsQuery.rangeValues);
    }

    if (hasValue(jsQuery.relationParameter)) {
        dotNetQuery.relationParameter = jsQuery.relationParameter;
    }

    if (hasValue(jsQuery.returnCentroid)) {
        dotNetQuery.returnCentroid = jsQuery.returnCentroid;
    }

    if (hasValue(jsQuery.returnDistinctValues)) {
        dotNetQuery.returnDistinctValues = jsQuery.returnDistinctValues;
    }

    if (hasValue(jsQuery.returnExceededLimitFeatures)) {
        dotNetQuery.returnExceededLimitFeatures = jsQuery.returnExceededLimitFeatures;
    }

    if (hasValue(jsQuery.returnGeometry)) {
        dotNetQuery.returnGeometry = jsQuery.returnGeometry;
    }

    if (hasValue(jsQuery.returnM)) {
        dotNetQuery.returnM = jsQuery.returnM;
    }

    if (hasValue(jsQuery.returnQueryGeometry)) {
        dotNetQuery.returnQueryGeometry = jsQuery.returnQueryGeometry;
    }

    if (hasValue(jsQuery.returnZ)) {
        dotNetQuery.returnZ = jsQuery.returnZ;
    }

    if (hasValue(jsQuery.spatialRelationship)) {
        dotNetQuery.spatialRelationship = removeCircularReferences(jsQuery.spatialRelationship);
    }

    if (hasValue(jsQuery.sqlFormat)) {
        dotNetQuery.sqlFormat = removeCircularReferences(jsQuery.sqlFormat);
    }

    if (hasValue(jsQuery.start)) {
        dotNetQuery.start = jsQuery.start;
    }

    if (hasValue(jsQuery.text)) {
        dotNetQuery.text = jsQuery.text;
    }

    if (hasValue(jsQuery.units)) {
        dotNetQuery.units = removeCircularReferences(jsQuery.units);
    }

    if (hasValue(jsQuery.where)) {
        dotNetQuery.where = jsQuery.where;
    }

    if (hasValue(viewId)) {
        let dotNetRef = dotNetRefs[viewId!];
        if (hasValue(dotNetRef)) {
            try {
                dotNetQuery.id = await dotNetRef.invokeMethodAsync('GetId');
                jsObjectRefs[dotNetQuery.id] = jsQuery;
            } catch (e) {
                console.error('Error invoking GetId for Query', e);
            }
        }
    }

    return dotNetQuery as DotNetQuery;
}
