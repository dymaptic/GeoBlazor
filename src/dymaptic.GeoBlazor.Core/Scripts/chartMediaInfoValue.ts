// override generated code in this file
import ChartMediaInfoValue from '@arcgis/core/popup/content/support/ChartMediaInfoValue';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';
import {buildDotNetChartMediaInfoValueSeries, buildJsChartMediaInfoValueSeries} from './chartMediaInfoValueSeries';

export function buildJsChartMediaInfoValue(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.colors)) {
        properties.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }
    if (hasValue(dotNetObject.series)) {
        properties.series = dotNetObject.series.map(i => buildJsChartMediaInfoValueSeries(i)) as any;
    }

    if (hasValue(dotNetObject.fields)) {
        properties.fields = dotNetObject.fields;
    }
    if (hasValue(dotNetObject.normalizeField)) {
        properties.normalizeField = dotNetObject.normalizeField;
    }
    if (hasValue(dotNetObject.tooltipField)) {
        properties.tooltipField = dotNetObject.tooltipField;
    }

    let jsChartMediaInfoValue = new ChartMediaInfoValue(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsChartMediaInfoValue);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsChartMediaInfoValue;

    return jsChartMediaInfoValue;
}

export function buildDotNetChartMediaInfoValue(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetChartMediaInfoValue: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        dotNetChartMediaInfoValue.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.series)) {
        dotNetChartMediaInfoValue.series = jsObject.series.map(i => buildDotNetChartMediaInfoValueSeries(i));
    }
    if (hasValue(jsObject.fields)) {
        dotNetChartMediaInfoValue.fields = jsObject.fields;
    }
    if (hasValue(jsObject.normalizeField)) {
        dotNetChartMediaInfoValue.normalizeField = jsObject.normalizeField;
    }
    if (hasValue(jsObject.tooltipField)) {
        dotNetChartMediaInfoValue.tooltipField = jsObject.tooltipField;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetChartMediaInfoValue.id = k;
                break;
            }
        }
    }

    return dotNetChartMediaInfoValue;
}
