// override generated code in this file
import ImageMediaInfo from '@arcgis/core/popup/content/ImageMediaInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetImageMediaInfoValue, buildJsImageMediaInfoValue} from './imageMediaInfoValue';

export function buildJsImageMediaInfo(dotNetObject: any, viewId: string | null): any {
    let properties: any = {};
    if (hasValue(dotNetObject.value)) {
        properties.value = buildJsImageMediaInfoValue(dotNetObject.value) as any;
    }

    if (hasValue(dotNetObject.altText)) {
        properties.altText = dotNetObject.altText;
    }
    if (hasValue(dotNetObject.caption)) {
        properties.caption = dotNetObject.caption;
    }
    if (hasValue(dotNetObject.refreshInterval)) {
        properties.refreshInterval = dotNetObject.refreshInterval;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsImageMediaInfo = new ImageMediaInfo(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsImageMediaInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsImageMediaInfo;

    return jsImageMediaInfo;
}

export function buildDotNetImageMediaInfo(jsObject: any, viewId: string | null): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetImageMediaInfo: any = {
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
