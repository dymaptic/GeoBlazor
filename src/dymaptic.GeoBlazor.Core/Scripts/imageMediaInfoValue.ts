// override generated code in this file

import ImageMediaInfoValue from "@arcgis/core/popup/content/support/ImageMediaInfoValue";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsImageMediaInfoValue(dotNetObject: any): any {
    let jsImageMediaInfoValue = new ImageMediaInfoValue();

    if (hasValue(dotNetObject.linkURL)) {
        jsImageMediaInfoValue.linkURL = dotNetObject.linkURL;
    }
    if (hasValue(dotNetObject.sourceURL)) {
        jsImageMediaInfoValue.sourceURL = dotNetObject.sourceURL;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(imageMediaInfoValueWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsImageMediaInfoValue;

    let dnInstantiatedObject = buildDotNetImageMediaInfoValue(jsImageMediaInfoValue);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ImageMediaInfoValue', e);
    }

    return jsImageMediaInfoValue;
}

export function buildDotNetImageMediaInfoValue(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetImageMediaInfoValue: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.linkURL)) {
        dotNetImageMediaInfoValue.linkURL = jsObject.linkURL;
    }
    if (hasValue(jsObject.sourceURL)) {
        dotNetImageMediaInfoValue.sourceURL = jsObject.sourceURL;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetImageMediaInfoValue.id = k;
                break;
            }
        }
    }

    return dotNetImageMediaInfoValue;
}
