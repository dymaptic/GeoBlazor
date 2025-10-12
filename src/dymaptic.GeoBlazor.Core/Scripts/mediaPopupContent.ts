// override generated code in this file
import MediaContent from "@arcgis/core/popup/content/MediaContent";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import {buildDotNetMediaInfo, buildJsMediaInfo} from './mediaInfo';


export function buildJsMediaPopupContent(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.mediaInfos)) {
        properties.mediaInfos = dotNetObject.mediaInfos.map(i => buildJsMediaInfo(i)) as any;
    }

    if (hasValue(dotNetObject.activeMediaInfoIndex)) {
        properties.activeMediaInfoIndex = dotNetObject.activeMediaInfoIndex;
    }
    if (hasValue(dotNetObject.description)) {
        properties.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsMediaContent = new MediaContent(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsMediaContent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMediaContent;

    return jsMediaContent;
}

export function buildDotNetMediaPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMediaPopupContent: any = {
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
