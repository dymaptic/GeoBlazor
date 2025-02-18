// override generated code in this file
import ImageMediaInfo from '@arcgis/core/popup/content/ImageMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetImageMediaInfoValue, buildJsImageMediaInfoValue } from './imageMediaInfoValue';

export function buildJsImageMediaInfo(dotNetObject: any): any {
    let jsImageMediaInfo = new ImageMediaInfo();
    if (hasValue(dotNetObject.value)) {
        jsImageMediaInfo.value = buildJsImageMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        jsImageMediaInfo.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        jsImageMediaInfo.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        jsImageMediaInfo.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.title)) {
        jsImageMediaInfo.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(imageMediaInfoWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsImageMediaInfo;

    let dnInstantiatedObject = buildDotNetImageMediaInfo(jsImageMediaInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ImageMediaInfo', e);
    }

    return jsImageMediaInfo;
}     

export function buildDotNetImageMediaInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetImageMediaInfo: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.value)) {
        dotNetImageMediaInfo.value = buildDotNetImageMediaInfoValue(jsObject.value);
    }
    if (hasValue(jsObject.altText)) {
        dotNetImageMediaInfo.altText = jsObject.altText;
    }
    if (hasValue(jsObject.caption)) {
        dotNetImageMediaInfo.caption = jsObject.caption;
    }
    if (hasValue(jsObject.refreshInterval)) {
        dotNetImageMediaInfo.refreshInterval = jsObject.refreshInterval;
    }
    if (hasValue(jsObject.title)) {
        dotNetImageMediaInfo.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetImageMediaInfo.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetImageMediaInfo.id = k;
                break;
            }
        }
    }

    return dotNetImageMediaInfo;
}
