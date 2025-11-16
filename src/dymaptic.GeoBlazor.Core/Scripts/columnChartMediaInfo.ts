// override generated code in this file

import ColumnChartMediaInfo from "@arcgis/core/popup/content/ColumnChartMediaInfo";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue} from "./chartMediaInfoValue";

export function buildJsColumnChartMediaInfo(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.value)) {
        properties.value = buildJsChartMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        properties.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        properties.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsColumnChartMediaInfo = new ColumnChartMediaInfo(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsColumnChartMediaInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColumnChartMediaInfo;

    return jsColumnChartMediaInfo;
}

export function buildDotNetColumnChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColumnChartMediaInfo: any = {
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
