// override generated code in this file

import ExpressionContent from '@arcgis/core/popup/content/ExpressionContent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import {buildDotNetElementExpressionInfo, buildJsElementExpressionInfo} from './elementExpressionInfo';

export function buildJsExpressionPopupContent(dotNetObject: any): any {
    let properties: any = {};
    if (hasValue(dotNetObject.expressionInfo)) {
        properties.expressionInfo = buildJsElementExpressionInfo(dotNetObject.expressionInfo) as any;
    }

    let jsExpressionContent = new ExpressionContent(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsExpressionContent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsExpressionContent;

    return jsExpressionContent;
}

export function buildDotNetExpressionPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetExpressionPopupContent: any = {
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
