// override generated code in this file
import TextPopupContentGenerated from './textPopupContent.gb';
import TextContent = __esri.TextContent;

export default class TextPopupContentWrapper extends TextPopupContentGenerated {

    constructor(component: TextContent) {
        super(component);
    }
    
}

export async function buildJsTextPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextPopupContentGenerated } = await import('./textPopupContent.gb');
    return await buildJsTextPopupContentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetTextPopupContentGenerated } = await import('./textPopupContent.gb');
    return await buildDotNetTextPopupContentGenerated(jsObject);
}
