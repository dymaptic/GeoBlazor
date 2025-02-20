// override generated code in this file

import ColumnChartMediaInfo from "@arcgis/core/popup/content/ColumnChartMediaInfo";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue} from "./chartMediaInfoValue";

export function buildJsColumnChartMediaInfo(dotNetObject: any): any {
    let jsColumnChartMediaInfo = new ColumnChartMediaInfo();
    if (hasValue(dotNetObject.value)) {
        jsColumnChartMediaInfo.value = buildJsChartMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        jsColumnChartMediaInfo.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        jsColumnChartMediaInfo.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.title)) {
        jsColumnChartMediaInfo.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(columnChartMediaInfoWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColumnChartMediaInfo;

    let dnInstantiatedObject = buildDotNetColumnChartMediaInfo(jsColumnChartMediaInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColumnChartMediaInfo', e);
    }

    return jsColumnChartMediaInfo;
}

export function buildDotNetColumnChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColumnChartMediaInfo: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.value)) {
        dotNetColumnChartMediaInfo.value = buildDotNetChartMediaInfoValue(jsObject.value);
    }
    if (hasValue(jsObject.altText)) {
        dotNetColumnChartMediaInfo.altText = jsObject.altText;
    }
    if (hasValue(jsObject.caption)) {
        dotNetColumnChartMediaInfo.caption = jsObject.caption;
    }
    if (hasValue(jsObject.title)) {
        dotNetColumnChartMediaInfo.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetColumnChartMediaInfo.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColumnChartMediaInfo.id = k;
                break;
            }
        }
    }

    return dotNetColumnChartMediaInfo;
}
