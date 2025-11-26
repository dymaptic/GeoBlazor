// override generated code in this file
import PopupTemplate from '@arcgis/core/PopupTemplate';
import {
    actionHandlers,
    arcGisObjectRefs,
    dotNetRefs,
    hasValue,
    jsObjectRefs,
    popupTemplateRefs
} from './geoBlazorCore';
import {buildJsPopupContent} from './popupContent';
import {buildDotNetGraphic} from './graphic';
import {buildJsFieldInfo} from './fieldInfo';
import {buildJsLayerOptions} from './layerOptions';
import {buildDotNetActionBase, buildJsActionBase} from "./actionBase";
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";
import {buildJsPopupExpressionInfo} from "./popupExpressionInfo";

export function buildJsPopupTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    let properties: any = {};
    if (hasValue(dotNetObject.content)) {
        properties.content = dotNetObject.content.map(c => buildJsPopupContent(c, layerId, viewId)) as any;
    } else if (hasValue(dotNetObject.stringContent)) {
        properties.content = dotNetObject.stringContent;
    } else if (hasValue(dotNetObject.hasContentFunction) && dotNetObject.hasContentFunction) {
        properties.content = async (featureSelection) => {
            let popupRef = await getPopupRef(dotNetObject.id, viewId);
            if (!hasValue(popupRef)) return null;
            let results: any | null = await popupRef
                .invokeMethodAsync("OnJsContentFunction", buildDotNetGraphic(featureSelection.graphic, layerId, viewId));
            return results?.map(r => buildJsPopupContent(r, layerId, viewId));        
        }
    }
    if (hasValue(dotNetObject.expressionInfos)) {
        properties.expressionInfos = dotNetObject.expressionInfos.map(i => buildJsPopupExpressionInfo(i)) as any;
    }
    if (hasValue(dotNetObject.fieldInfos)) {
        properties.fieldInfos = dotNetObject.fieldInfos.map(i => buildJsFieldInfo(i)) as any;
    }
    if (hasValue(dotNetObject.layerOptions)) {
        properties.layerOptions = buildJsLayerOptions(dotNetObject.layerOptions) as any;
    }

    if (hasValue(dotNetObject.actions)) {
        properties.actions = dotNetObject.actions.map(buildJsActionBase) as any;

        if (hasValue(viewId)) {
            let view = arcGisObjectRefs[viewId!];
            if (hasValue(view)) {
                if (!hasValue(view.popup.on)) {
                    reactiveUtils.once(() => view.popup.on !== undefined)
                        .then(() => {
                            setTriggerActionHandlers(dotNetObject, view, viewId);
                        })
                } else {
                    setTriggerActionHandlers(dotNetObject, view, viewId);
                }   
            }
        }
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

function setTriggerActionHandlers(dotNetObject, view, viewId) {
    if (actionHandlers.hasOwnProperty(dotNetObject.id)) {
        actionHandlers[dotNetObject.id].remove();
        delete actionHandlers[dotNetObject.id];
    }

    let handler = view.popup.on('trigger-action', async (evt: any) => {
        for (let i = 0; i < dotNetObject.actions.length; i++) {
            let dnAction = dotNetObject.actions[i];
            let actionRef = await getActionRef(dnAction.id, viewId);
            if (!hasValue(actionRef)) return;
            await actionRef.invokeMethodAsync("OnJsTriggerAction", {
                action: await buildDotNetActionBase(evt.action)
            });
        }
        let popupRef = await getPopupRef(dotNetObject.id, viewId);
        if (!hasValue(popupRef)) return;
        await popupRef.invokeMethodAsync("OnJsTriggerAction", {
            action: await buildDotNetActionBase(evt.action)
        });
    });

    actionHandlers[dotNetObject.id] = handler;
}

async function getPopupRef(popupId, viewId) {
    if (viewId === null || !arcGisObjectRefs.hasOwnProperty(viewId)) {
        return null;
    }
    let viewRef = dotNetRefs[viewId];
    let popupRef = dotNetRefs[popupId];
    if (!hasValue(popupRef)) {
        popupRef = await viewRef.invokeMethodAsync('GetDotNetPopupTemplateObjectReference', popupId);
        if (hasValue(popupRef)) {
            dotNetRefs[popupId] = popupRef;
        }
    }

    return popupRef;
}

async function getActionRef(actionId, viewId) {
    if (viewId === null || !arcGisObjectRefs.hasOwnProperty(viewId)) {
        return null;
    }
    let viewRef = dotNetRefs[viewId];
    let actionRef = dotNetRefs[actionId];
    if (!hasValue(actionRef)) {
        actionRef = await viewRef.invokeMethodAsync('GetDotNetActionObjectReference', actionId);
        if (hasValue(actionRef)) {
            dotNetRefs[actionId] = actionRef;
        }
    }

    return actionRef;
}
