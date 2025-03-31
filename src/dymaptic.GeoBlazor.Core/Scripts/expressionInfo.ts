// override generated code in this file

import ExpressionInfo from "@arcgis/core/form/ExpressionInfo";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsExpressionInfo(dotNetObject: any): any {
    let properties: any = {};

    if (hasValue(dotNetObject.expression)) {
        properties.expression = dotNetObject.expression;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.returnType)) {
        properties.returnType = dotNetObject.returnType;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsExpressionInfo = new ExpressionInfo(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsExpressionInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsExpressionInfo;

    return jsExpressionInfo;
}

export function buildDotNetExpressionInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetExpressionInfo: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.expression)) {
        dotNetExpressionInfo.expression = jsObject.expression;
    }
    if (hasValue(jsObject.name)) {
        dotNetExpressionInfo.name = jsObject.name;
    }
    if (hasValue(jsObject.returnType)) {
        dotNetExpressionInfo.returnType = jsObject.returnType;
    }
    if (hasValue(jsObject.title)) {
        dotNetExpressionInfo.title = jsObject.title;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetExpressionInfo.id = k;
                break;
            }
        }
    }

    return dotNetExpressionInfo;
}
