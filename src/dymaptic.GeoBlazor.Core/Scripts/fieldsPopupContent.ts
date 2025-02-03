// override generated code in this file
import FieldsPopupContentGenerated from './fieldsPopupContent.gb';
import FieldsContent = __esri.FieldsContent;

export default class FieldsPopupContentWrapper extends FieldsPopupContentGenerated {

    constructor(component: FieldsContent) {
        super(component);
    }
    
}

export async function buildJsFieldsPopupContent(dotNetObject: any): Promise<any> {
    let { buildJsFieldsPopupContentGenerated } = await import('./fieldsPopupContent.gb');
    return await buildJsFieldsPopupContentGenerated(dotNetObject);
}     

export async function buildDotNetFieldsPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetFieldsPopupContentGenerated } = await import('./fieldsPopupContent.gb');
    return await buildDotNetFieldsPopupContentGenerated(jsObject);
}
