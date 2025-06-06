// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import AggregateField from '@arcgis/core/layers/support/AggregateField';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetAggregateField } from './aggregateField';

export async function buildJsAggregateFieldGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.onStatisticExpression)) {
        let { buildJsSupportExpressionInfo } = await import('./supportExpressionInfo');
        properties.onStatisticExpression = await buildJsSupportExpressionInfo(dotNetObject.onStatisticExpression, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.alias)) {
        properties.alias = dotNetObject.alias;
    }
    if (hasValue(dotNetObject.isAutoGenerated)) {
        properties.isAutoGenerated = dotNetObject.isAutoGenerated;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.onStatisticField)) {
        properties.onStatisticField = dotNetObject.onStatisticField;
    }
    if (hasValue(dotNetObject.statisticType)) {
        properties.statisticType = dotNetObject.statisticType;
    }
    let jsAggregateField = new AggregateField(properties);
    
    jsObjectRefs[dotNetObject.id] = jsAggregateField;
    arcGisObjectRefs[dotNetObject.id] = jsAggregateField;
    
    return jsAggregateField;
}


export async function buildDotNetAggregateFieldGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetAggregateField: any = {};
    
    if (hasValue(jsObject.onStatisticExpression)) {
        let { buildDotNetSupportExpressionInfo } = await import('./supportExpressionInfo');
        dotNetAggregateField.onStatisticExpression = await buildDotNetSupportExpressionInfo(jsObject.onStatisticExpression);
    }
    
    if (hasValue(jsObject.alias)) {
        dotNetAggregateField.alias = jsObject.alias;
    }
    
    if (hasValue(jsObject.isAutoGenerated)) {
        dotNetAggregateField.isAutoGenerated = jsObject.isAutoGenerated;
    }
    
    if (hasValue(jsObject.name)) {
        dotNetAggregateField.name = jsObject.name;
    }
    
    if (hasValue(jsObject.onStatisticField)) {
        dotNetAggregateField.onStatisticField = jsObject.onStatisticField;
    }
    
    if (hasValue(jsObject.statisticType)) {
        dotNetAggregateField.statisticType = removeCircularReferences(jsObject.statisticType);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetAggregateField.id = geoBlazorId;
    }

    return dotNetAggregateField;
}

