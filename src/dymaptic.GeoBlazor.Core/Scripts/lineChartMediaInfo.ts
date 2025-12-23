// override generated code in this file
import LineChartMediaInfo from '@arcgis/core/popup/content/LineChartMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue} from './chartMediaInfoValue';


export function buildJsLineChartMediaInfo(dotNetObject: any): any {
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

    let jsLineChartMediaInfo = new LineChartMediaInfo(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsLineChartMediaInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLineChartMediaInfo;

    return jsLineChartMediaInfo;
}

export function buildDotNetLineChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLineChartMediaInfo: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.value)) {
        dotNetLineChartMediaInfo.value = buildDotNetChartMediaInfoValue(jsObject.value);
    }
    if (hasValue(jsObject.altText)) {
        dotNetLineChartMediaInfo.altText = jsObject.altText;
    }
    if (hasValue(jsObject.caption)) {
        dotNetLineChartMediaInfo.caption = jsObject.caption;
    }
    if (hasValue(jsObject.title)) {
        dotNetLineChartMediaInfo.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetLineChartMediaInfo.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLineChartMediaInfo.id = k;
                break;
            }
        }
    }

    return dotNetLineChartMediaInfo;
}
