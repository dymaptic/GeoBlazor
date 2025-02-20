// override generated code in this file
import PopupTemplate from '@arcgis/core/PopupTemplate';
import {arcGisObjectRefs, dotNetRefs, hasValue, jsObjectRefs, popupTemplateRefs} from "./arcGisJsInterop";
import {buildJsPopupContent} from './popupContent';
import {buildJsExpressionInfo} from './expressionInfo';
import {buildDotNetGraphic} from './graphic';
import {buildJsFieldInfo} from './fieldInfo';
import {buildJsLayerOptions} from './layerOptions';

export function buildJsPopupTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    let jsPopupTemplate = new PopupTemplate();
    if (hasValue(dotNetObject.content)) {
        jsPopupTemplate.content = dotNetObject.content.map(buildJsPopupContent) as any;
    } else if (hasValue(dotNetObject.stringContent)) {
        jsPopupTemplate.content = dotNetObject.stringContent;
    } else if (hasValue(dotNetObject.hasContentFunction) && dotNetObject.hasContentFunction) {
        jsPopupTemplate.content = async (featureSelection) => {
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
        jsPopupTemplate.expressionInfos = dotNetObject.expressionInfos.map(i => buildJsExpressionInfo(i)) as any;
    }
    if (hasValue(dotNetObject.fieldInfos)) {
        jsPopupTemplate.fieldInfos = dotNetObject.fieldInfos.map(i => buildJsFieldInfo(i)) as any;
    }
    if (hasValue(dotNetObject.layerOptions)) {
        jsPopupTemplate.layerOptions = buildJsLayerOptions(dotNetObject.layerOptions) as any;
    }

    if (hasValue(dotNetObject.actions)) {
        jsPopupTemplate.actions = dotNetObject.actions;
    }
    if (hasValue(dotNetObject.lastEditInfoEnabled)) {
        jsPopupTemplate.lastEditInfoEnabled = dotNetObject.lastEditInfoEnabled;
    }
    if (hasValue(dotNetObject.outFields)) {
        jsPopupTemplate.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.overwriteActions)) {
        jsPopupTemplate.overwriteActions = dotNetObject.overwriteActions;
    }
    if (hasValue(dotNetObject.returnGeometry)) {
        jsPopupTemplate.returnGeometry = dotNetObject.returnGeometry;
    }
    if (hasValue(dotNetObject.title)) {
        jsPopupTemplate.title = dotNetObject.title;
    }

        let jsObjectRef = DotNet.createJSObjectReference(jsPopupTemplate);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPopupTemplate;

    let dnInstantiatedObject = buildDotNetPopupTemplate(jsPopupTemplate);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PopupTemplate', e);
    }

    popupTemplateRefs[dotNetObject.id] = jsPopupTemplate;

    return jsPopupTemplate;
}

export async function buildDotNetPopupTemplate(jsObject: any): Promise<any> {
    let {buildDotNetPopupTemplateGenerated} = await import('./popupTemplate.gb');
    let result = await buildDotNetPopupTemplateGenerated(jsObject);
    if (typeof jsObject.content === 'string') {
        result.stringContent = jsObject.content;
    }

    return result;
}
