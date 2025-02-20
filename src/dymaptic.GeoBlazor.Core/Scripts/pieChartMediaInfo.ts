// override generated code in this file
import PieChartMediaInfo from '@arcgis/core/popup/content/PieChartMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue} from './chartMediaInfoValue';


export function buildJsPieChartMediaInfo(dotNetObject: any): any {
    let jsPieChartMediaInfo = new PieChartMediaInfo();
    if (hasValue(dotNetObject.value)) {
        jsPieChartMediaInfo.value = buildJsChartMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        jsPieChartMediaInfo.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        jsPieChartMediaInfo.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.title)) {
        jsPieChartMediaInfo.title = dotNetObject.title;
    }

        let jsObjectRef = DotNet.createJSObjectReference(jsPieChartMediaInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPieChartMediaInfo;

    let dnInstantiatedObject = buildDotNetPieChartMediaInfo(jsPieChartMediaInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PieChartMediaInfo', e);
    }

    return jsPieChartMediaInfo;
}

export function buildDotNetPieChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPieChartMediaInfo: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.value)) {
        dotNetPieChartMediaInfo.value = buildDotNetChartMediaInfoValue(jsObject.value);
    }
    if (hasValue(jsObject.altText)) {
        dotNetPieChartMediaInfo.altText = jsObject.altText;
    }
    if (hasValue(jsObject.caption)) {
        dotNetPieChartMediaInfo.caption = jsObject.caption;
    }
    if (hasValue(jsObject.title)) {
        dotNetPieChartMediaInfo.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetPieChartMediaInfo.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPieChartMediaInfo.id = k;
                break;
            }
        }
    }

    return dotNetPieChartMediaInfo;
}
