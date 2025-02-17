// override generated code in this file
import LineChartMediaInfo from '@arcgis/core/popup/content/LineChartMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue } from './chartMediaInfoValue';


export function buildJsLineChartMediaInfo(dotNetObject: any): any {
    let jsLineChartMediaInfo = new LineChartMediaInfo();
    if (hasValue(dotNetObject.value)) {
        jsLineChartMediaInfo.value = buildJsChartMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        jsLineChartMediaInfo.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        jsLineChartMediaInfo.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.title)) {
        jsLineChartMediaInfo.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(lineChartMediaInfoWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLineChartMediaInfo;

    let dnInstantiatedObject = buildDotNetLineChartMediaInfo(jsLineChartMediaInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LineChartMediaInfo', e);
    }

    return jsLineChartMediaInfo;
}     

export function buildDotNetLineChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLineChartMediaInfo: any = {
        // @ts-ignore
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
