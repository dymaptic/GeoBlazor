// override generated code in this file
import BarChartMediaInfo from '@arcgis/core/popup/content/BarChartMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue} from './chartMediaInfoValue';


export function buildJsBarChartMediaInfo(dotNetObject: any): any {
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
    
    let jsBarChartMediaInfo = new BarChartMediaInfo(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsBarChartMediaInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBarChartMediaInfo;

    return jsBarChartMediaInfo;
}

export function buildDotNetBarChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBarChartMediaInfo: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.value)) {
        dotNetBarChartMediaInfo.value = buildDotNetChartMediaInfoValue(jsObject.value);
    }
    if (hasValue(jsObject.altText)) {
        dotNetBarChartMediaInfo.altText = jsObject.altText;
    }
    if (hasValue(jsObject.caption)) {
        dotNetBarChartMediaInfo.caption = jsObject.caption;
    }
    if (hasValue(jsObject.title)) {
        dotNetBarChartMediaInfo.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetBarChartMediaInfo.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBarChartMediaInfo.id = k;
                break;
            }
        }
    }

    return dotNetBarChartMediaInfo;
}
