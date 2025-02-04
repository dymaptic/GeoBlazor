// override generated code in this file
import PopupContentGenerated from './popupContent.gb';
import Content = __esri.Content;

export default class PopupContentWrapper extends PopupContentGenerated {

    constructor(component: Content) {
        super(component);
    }
    
}

export async function buildJsPopupContent(dotNetObject: any): Promise<any> {
    let { buildJsPopupContentGenerated } = await import('./popupContent.gb');
    return await buildJsPopupContentGenerated(dotNetObject);
}     

export async function buildDotNetPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetPopupContentGenerated } = await import('./popupContent.gb');
    return await buildDotNetPopupContentGenerated(jsObject);
}
