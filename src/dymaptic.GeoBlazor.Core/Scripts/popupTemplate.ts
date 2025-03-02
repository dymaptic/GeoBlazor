// override generated code in this file
import PopupTemplate from '@arcgis/core/PopupTemplate';
import {arcGisObjectRefs, dotNetRefs, hasValue, jsObjectRefs, popupTemplateRefs} from "./arcGisJsInterop";
import {buildJsPopupContent} from './popupContent';
import {buildJsExpressionInfo} from './expressionInfo';
import {buildDotNetGraphic} from './graphic';
import {buildJsFieldInfo} from './fieldInfo';
import {buildJsLayerOptions} from './layerOptions';

export function buildJsPopupTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    let properties: any = {};
    if (hasValue(dotNetObject.content)) {
        properties.content = dotNetObject.content.map(buildJsPopupContent) as any;
    } else if (hasValue(dotNetObject.stringContent)) {
        properties.content = dotNetObject.stringContent;
    } else if (hasValue(dotNetObject.hasContentFunction) && dotNetObject.hasContentFunction) {
        properties.content = async (featureSelection) => {
            try {
                if (viewId === null || !arcGisObjectRefs.hasOwnProperty(viewId)) {
                    return;
                }
                let viewRef = dotNetRefs[viewId];
                let popupRef = dotNetRefs[dotNetObject.id];
                if (!hasValue(popupRef)) {
                    popupRef = await viewRef.invokeMethodAsync('GetDotNetPopupTemplateObjectReference', dotNetObject.id);
                    if (hasValue(popupRef)) {
                        dotNetRefs[dotNetObject.id] = popupRef;
                    }
                }

                if (!hasValue(popupRef)) return null;
                let results: any | null = await popupRef
                    .invokeMethodAsync("OnJsContentFunction", buildDotNetGraphic(featureSelection.graphic, layerId, viewId));
                return results?.map(r => buildJsPopupContent(r));
            } catch (error) {
                console.error(error);
                return null;
            }
        }
    }
    if (hasValue(dotNetObject.expressionInfos)) {
        properties.expressionInfos = dotNetObject.expressionInfos.map(i => buildJsExpressionInfo(i)) as any;
    }
    if (hasValue(dotNetObject.fieldInfos)) {
        properties.fieldInfos = dotNetObject.fieldInfos.map(i => buildJsFieldInfo(i)) as any;
    }
    if (hasValue(dotNetObject.layerOptions)) {
        properties.layerOptions = buildJsLayerOptions(dotNetObject.layerOptions) as any;
    }

    if (hasValue(dotNetObject.actions)) {
        properties.actions = dotNetObject.actions;
    }
    if (hasValue(dotNetObject.lastEditInfoEnabled)) {
        properties.lastEditInfoEnabled = dotNetObject.lastEditInfoEnabled;
    }
    if (hasValue(dotNetObject.outFields)) {
        properties.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.overwriteActions)) {
        properties.overwriteActions = dotNetObject.overwriteActions;
    }
    if (hasValue(dotNetObject.returnGeometry)) {
        properties.returnGeometry = dotNetObject.returnGeometry;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }

    let jsPopupTemplate = new PopupTemplate(properties);
    let jsObjectRef = DotNet.createJSObjectReference(jsPopupTemplate);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPopupTemplate;
    popupTemplateRefs[dotNetObject.id] = jsPopupTemplate;

    return jsPopupTemplate;
}

export async function buildDotNetPopupTemplate(jsObject: any): Promise<any> {
    let {buildDotNetPopupTemplateGenerated} = await import('./popupTemplate.gb');
    let result = await buildDotNetPopupTemplateGenerated(jsObject);
    if (typeof jsObject.content === 'string') {
        result.stringContent = jsObject.content;
    } else if (Array.isArray(jsObject.content)) {
        let { buildDotNetPopupContent } = await import('./popupContent');
        result.content = jsObject.content.map(i => buildDotNetPopupContent(i));
    }

    return result;
}
