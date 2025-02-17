// override generated code in this file
import ChartMediaInfoValueSeries from '@arcgis/core/popup/content/support/ChartMediaInfoValueSeries';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor } from './mapColor';

export function buildJsChartMediaInfoValueSeries(dotNetObject: any): any {
    let jsChartMediaInfoValueSeries = new ChartMediaInfoValueSeries();

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(chartMediaInfoValueSeriesWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsChartMediaInfoValueSeries;

    let dnInstantiatedObject = buildDotNetChartMediaInfoValueSeries(jsChartMediaInfoValueSeries);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ChartMediaInfoValueSeries', e);
    }

    return jsChartMediaInfoValueSeries;
}

export function buildDotNetChartMediaInfoValueSeries(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetChartMediaInfoValueSeries: any = {
        // @ts-ignore
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
