// override generated code in this file
import PopupTemplateGenerated from './popupTemplate.gb';
import PopupTemplate from '@arcgis/core/PopupTemplate';

export default class PopupTemplateWrapper extends PopupTemplateGenerated {

    constructor(component: PopupTemplate) {
        super(component);
    }
    
}              
export async function buildJsPopupTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupTemplateGenerated } = await import('./popupTemplate.gb');
    return await buildJsPopupTemplateGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPopupTemplate(jsObject: any): Promise<any> {
    let { buildDotNetPopupTemplateGenerated } = await import('./popupTemplate.gb');
    return await buildDotNetPopupTemplateGenerated(jsObject);
}
