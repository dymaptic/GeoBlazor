import templates = __esri.templates;
import PopupTemplateCreatorGenerated from './popupTemplateCreator.gb';

export default class PopupTemplateCreatorWrapper extends PopupTemplateCreatorGenerated {

    constructor(component: templates) {
        super(component);
    }
    
}

export async function buildJsPopupTemplateCreator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupTemplateCreatorGenerated } = await import('./popupTemplateCreator.gb');
    return await buildJsPopupTemplateCreatorGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPopupTemplateCreator(jsObject: any): Promise<any> {
    let { buildDotNetPopupTemplateCreatorGenerated } = await import('./popupTemplateCreator.gb');
    return await buildDotNetPopupTemplateCreatorGenerated(jsObject);
}
