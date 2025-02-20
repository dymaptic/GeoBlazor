// override generated code in this file
import BarChartMediaInfo from '@arcgis/core/popup/content/BarChartMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetChartMediaInfoValue, buildJsChartMediaInfoValue} from './chartMediaInfoValue';


export function buildJsBarChartMediaInfo(dotNetObject: any): any {
    let jsBarChartMediaInfo = new BarChartMediaInfo();
    if (hasValue(dotNetObject.value)) {
        jsBarChartMediaInfo.value = buildJsChartMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        jsBarChartMediaInfo.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        jsBarChartMediaInfo.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.title)) {
        jsBarChartMediaInfo.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(barChartMediaInfoWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBarChartMediaInfo;

    let dnInstantiatedObject = buildDotNetBarChartMediaInfo(jsBarChartMediaInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BarChartMediaInfo', e);
    }

    return jsBarChartMediaInfo;
}

export function buildDotNetBarChartMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBarChartMediaInfo: any = {
        // @ts-ignore
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
