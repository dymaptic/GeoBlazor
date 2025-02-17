// override generated code in this file
import MediaContent = __esri.MediaContent;
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMediaInfo, buildJsMediaInfo } from './mediaInfo';


export function buildJsMediaPopupContent(dotNetObject: any): any {
    let jsMediaContent = new MediaContent();
    if (hasValue(dotNetObject.mediaInfos)) {
        jsMediaContent.mediaInfos = dotNetObject.mediaInfos.map(i => buildJsMediaInfo(i)) as any;
    }

    if (hasValue(dotNetObject.activeMediaInfoIndex)) {
        jsMediaContent.activeMediaInfoIndex = dotNetObject.activeMediaInfoIndex;
    }
    if (hasValue(dotNetObject.description)) {
        jsMediaContent.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.title)) {
        jsMediaContent.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(mediaPopupContentWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMediaContent;

    let dnInstantiatedObject = buildDotNetMediaPopupContent(jsMediaContent);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MediaPopupContent', e);
    }

    return jsMediaContent;
}     

export function buildDotNetMediaPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMediaPopupContent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.mediaInfos)) {
        dotNetMediaPopupContent.mediaInfos = jsObject.mediaInfos.map(i => buildDotNetMediaInfo(i));
    }
    if (hasValue(jsObject.activeMediaInfoIndex)) {
        dotNetMediaPopupContent.activeMediaInfoIndex = jsObject.activeMediaInfoIndex;
    }
    if (hasValue(jsObject.description)) {
        dotNetMediaPopupContent.description = jsObject.description;
    }
    if (hasValue(jsObject.title)) {
        dotNetMediaPopupContent.title = jsObject.title;
    }
    if (hasValue(jsObject.type)) {
        dotNetMediaPopupContent.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMediaPopupContent.id = k;
                break;
            }
        }
    }

    return dotNetMediaPopupContent;
}
