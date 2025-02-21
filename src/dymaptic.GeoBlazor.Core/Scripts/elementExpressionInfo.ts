// override generated code in this file
import ElementExpressionInfo from '@arcgis/core/popup/ElementExpressionInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsElementExpressionInfo(dotNetObject: any): any {
    let jsElementExpressionInfo = new ElementExpressionInfo();

    if (hasValue(dotNetObject.expression)) {
        jsElementExpressionInfo.expression = dotNetObject.expression;
    }
    if (hasValue(dotNetObject.returnType)) {
        jsElementExpressionInfo.returnType = dotNetObject.returnType;
    }
    if (hasValue(dotNetObject.title)) {
        jsElementExpressionInfo.title = dotNetObject.title;
    }

    let jsObjectRef = DotNet.createJSObjectReference(jsElementExpressionInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsElementExpressionInfo;

    return jsElementExpressionInfo;
}

export function buildDotNetElementExpressionInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetElementExpressionInfo: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.expression)) {
        dotNetElementExpressionInfo.expression = jsObject.expression;
    }
    if (hasValue(jsObject.returnType)) {
        dotNetElementExpressionInfo.returnType = jsObject.returnType;
    }
    if (hasValue(jsObject.title)) {
        dotNetElementExpressionInfo.title = jsObject.title;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetElementExpressionInfo.id = k;
                break;
            }
        }
    }

    return dotNetElementExpressionInfo;
}
