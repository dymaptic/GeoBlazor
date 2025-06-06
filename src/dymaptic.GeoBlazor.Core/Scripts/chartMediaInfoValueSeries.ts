// override generated code in this file
import ChartMediaInfoValueSeries from '@arcgis/core/popup/content/support/ChartMediaInfoValueSeries';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor} from './mapColor';

export function buildJsChartMediaInfoValueSeries(dotNetObject: any): any {
    let properties: any = {};
    
    if (hasValue(dotNetObject.color)) {
        properties.color = dotNetObject.color;
    }
    
    if (hasValue(dotNetObject.fieldName)) {
        properties.fieldName = dotNetObject.fieldName;
    }
    
    if (hasValue(dotNetObject.tooltip)) {
        properties.tooltip = dotNetObject.tooltip;
    }
    
    if (hasValue(dotNetObject.value)) {
        properties.value = dotNetObject.value;
    }
    
    let jsChartMediaInfoValueSeries = new ChartMediaInfoValueSeries(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsChartMediaInfoValueSeries);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsChartMediaInfoValueSeries;
    
    return jsChartMediaInfoValueSeries;
}

export function buildDotNetChartMediaInfoValueSeries(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetChartMediaInfoValueSeries: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        dotNetChartMediaInfoValueSeries.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.fieldName)) {
        dotNetChartMediaInfoValueSeries.fieldName = jsObject.fieldName;
    }
    if (hasValue(jsObject.tooltip)) {
        dotNetChartMediaInfoValueSeries.tooltip = jsObject.tooltip;
    }
    if (hasValue(jsObject.value)) {
        dotNetChartMediaInfoValueSeries.value = jsObject.value;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetChartMediaInfoValueSeries.id = k;
                break;
            }
        }
    }

    return dotNetChartMediaInfoValueSeries;
}
