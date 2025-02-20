// override generated code in this file

import ExpressionInfo from "@arcgis/core/form/ExpressionInfo";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export function buildJsExpressionInfo(dotNetObject: any): any {
    let jsExpressionInfo = new ExpressionInfo();

    if (hasValue(dotNetObject.expression)) {
        jsExpressionInfo.expression = dotNetObject.expression;
    }
    if (hasValue(dotNetObject.name)) {
        jsExpressionInfo.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.returnType)) {
        jsExpressionInfo.returnType = dotNetObject.returnType;
    }
    if (hasValue(dotNetObject.title)) {
        jsExpressionInfo.title = dotNetObject.title;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(expressionInfoWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsExpressionInfo;

    let dnInstantiatedObject = buildDotNetExpressionInfo(jsExpressionInfo);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ExpressionInfo', e);
    }

    return jsExpressionInfo;
}

export function buildDotNetExpressionInfo(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetExpressionInfo: any = {
        // @ts-ignore
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
