// override generated code in this file
import PopupTemplateGenerated from './popupTemplate.gb';
import PopupTemplate from '@arcgis/core/PopupTemplate';

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
    return await buildJsPopupTemplateGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPopupTemplate(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPopupTemplateGenerated } = await import('./popupTemplate.gb');
    return await buildDotNetPopupTemplateGenerated(jsObject, layerId, viewId);
}
