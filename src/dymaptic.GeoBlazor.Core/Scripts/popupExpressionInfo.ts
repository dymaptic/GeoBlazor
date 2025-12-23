import popupExpressionInfo from "@arcgis/core/popup/ExpressionInfo";
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';

export function buildJsPopupExpressionInfo(dotNetObject: any): any {
    if (!hasValue(dotNetObject)) {
        return null;
    }

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
    let jspopupExpressionInfo = new popupExpressionInfo(properties);

    jsObjectRefs[dotNetObject.id] = jspopupExpressionInfo;
    arcGisObjectRefs[dotNetObject.id] = jspopupExpressionInfo;

    return jspopupExpressionInfo;
}     

export async function buildDotNetPopupExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildDotNetPopupExpressionInfoGenerated(jsObject);
}
