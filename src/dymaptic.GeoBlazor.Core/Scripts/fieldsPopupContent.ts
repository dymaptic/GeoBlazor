// override generated code in this file
import FieldsPopupContentGenerated from './fieldsPopupContent.gb';
import FieldsContent = __esri.FieldsContent;

export default class FieldsPopupContentWrapper extends FieldsPopupContentGenerated {

    constructor(component: FieldsContent) {
        super(component);
    }
    
}

export async function buildJsFieldsPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldsPopupContentGenerated } = await import('./fieldsPopupContent.gb');
    return await buildJsFieldsPopupContentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldsPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetFieldsPopupContentGenerated } = await import('./fieldsPopupContent.gb');
    return await buildDotNetFieldsPopupContentGenerated(jsObject);
}
