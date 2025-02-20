// override generated code in this file

import ExpressionContent from '@arcgis/core/popup/content/ExpressionContent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {buildDotNetElementExpressionInfo, buildJsElementExpressionInfo} from './elementExpressionInfo';

export function buildJsExpressionPopupContent(dotNetObject: any): any {
    let jsExpressionContent = new ExpressionContent();
    if (hasValue(dotNetObject.expressionInfo)) {
        jsExpressionContent.expressionInfo = buildJsElementExpressionInfo(dotNetObject.expressionInfo) as any;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(expressionPopupContentWrapper);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsExpressionContent;

    let dnInstantiatedObject = buildDotNetExpressionPopupContent(jsExpressionContent);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ExpressionPopupContent', e);
    }

    return jsExpressionContent;
}

export function buildDotNetExpressionPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetExpressionPopupContent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.expressionInfo)) {
        dotNetExpressionPopupContent.expressionInfo = buildDotNetElementExpressionInfo(jsObject.expressionInfo);
    }
    if (hasValue(jsObject.type)) {
        dotNetExpressionPopupContent.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetExpressionPopupContent.id = k;
                break;
            }
        }
    }

    return dotNetExpressionPopupContent;
}
