// override generated code in this file
import ChartMediaInfoValue from '@arcgis/core/popup/content/support/ChartMediaInfoValue';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';
import {buildDotNetChartMediaInfoValueSeries, buildJsChartMediaInfoValueSeries} from './chartMediaInfoValueSeries';

export function buildJsChartMediaInfoValue(dotNetObject: any): any {
    let jsChartMediaInfoValue = new ChartMediaInfoValue();
    if (hasValue(dotNetObject.colors)) {
        jsChartMediaInfoValue.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }
    if (hasValue(dotNetObject.series)) {
        jsChartMediaInfoValue.series = dotNetObject.series.map(i => buildJsChartMediaInfoValueSeries(i)) as any;
    }

    if (hasValue(dotNetObject.fields)) {
        jsChartMediaInfoValue.fields = dotNetObject.fields;
    }
    if (hasValue(dotNetObject.normalizeField)) {
        jsChartMediaInfoValue.normalizeField = dotNetObject.normalizeField;
    }
    if (hasValue(dotNetObject.tooltipField)) {
        jsChartMediaInfoValue.tooltipField = dotNetObject.tooltipField;
    }

        let jsObjectRef = DotNet.createJSObjectReference(jsChartMediaInfoValue);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsChartMediaInfoValue;

    let dnInstantiatedObject = buildDotNetChartMediaInfoValue(jsChartMediaInfoValue);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ChartMediaInfoValue', e);
    }

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
