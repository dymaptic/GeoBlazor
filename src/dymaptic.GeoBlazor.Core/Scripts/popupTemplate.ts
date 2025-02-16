// override generated code in this file
import PopupTemplateGenerated from './popupTemplate.gb';
import PopupTemplate from '@arcgis/core/PopupTemplate';
import {DotNetPopupContent, DotNetPopupTemplate} from "./definitions";
import {
    arcGisObjectRefs, buildJsAction, buildJsExpressionInfo,
    buildJsFieldInfo,
    buildJsPopupContent,
    dotNetRefs,
    hasValue,
    popupTemplateRefs
} from "./arcGisJsInterop";

export default class PopupTemplateWrapper extends PopupTemplateGenerated {

    constructor(component: PopupTemplate) {
        super(component);
    }

    async getContent(): Promise<any> {
        let { buildDotNetPopupContent } = await import('./popupContent');
        if (!this.component.content) {
            return null;
        }
        
        if (Array.isArray(this.component.content)) {
            return this.component.content.map(async i => await buildDotNetPopupContent(i));
        }

        return this.component.content;
    }
    
}              
export async function buildJsPopupTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupTemplateGenerated } = await import('./popupTemplate.gb');
    let template = await buildJsPopupTemplateGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.stringContent)) {
        template.content = dotNetObject.stringContent;
    } else if (hasValue(dotNetObject.hasContentFunction) && dotNetObject.hasContentFunction) {
        template.content = async (featureSelection) => {
            try {
                if (viewId === null || !arcGisObjectRefs.hasOwnProperty(viewId)) {
                    return;
                }
                let viewRef = dotNetRefs[viewId];
                let popupRef = dotNetRefs[dotNetObject.id];
                if (!hasValue(popupRef)) {
                    popupRef = await viewRef.invokeMethodAsync('GetDotNetdotNetObjectReference', dotNetObject.id);
                    if (hasValue(popupRef)) {
                        dotNetRefs[dotNetObject.id] = popupRef;
                    }
                }

                if (!hasValue(popupRef)) return null;
                let {buildDotNetGraphic} = await import('./graphic');
                let results: DotNetPopupContent[] | null = await popupRef
                    .invokeMethodAsync("OnContentFunction", buildDotNetGraphic(featureSelection.graphic, layerId, viewId));
                return results?.map(buildJsPopupContent);
            } catch (error) {
                console.error(error);
                return null;
            }
        }
    }
    popupTemplateRefs[dotNetObject.id] = template;

    return template;
}
export async function buildDotNetPopupTemplate(jsObject: any): Promise<any> {
    let { buildDotNetPopupTemplateGenerated } = await import('./popupTemplate.gb');
    let result = await buildDotNetPopupTemplateGenerated(jsObject);
    if (typeof jsObject.content === 'string') {
        result.stringContent = jsObject.content;
    }
    
    return result;
}
