// override generated code in this file
import FormElementGenerated from './formElement.gb';
import Element = __esri.Element;

export default class FormElementWrapper extends FormElementGenerated {

    constructor(component: Element) {
        super(component);
    }
    
}

export async function buildJsFormElement(dotNetObject: any): Promise<any> {
    let { buildJsFormElementGenerated } = await import('./formElement.gb');
    return await buildJsFormElementGenerated(dotNetObject);
}     

export async function buildDotNetFormElement(jsObject: any): Promise<any> {
    let { buildDotNetFormElementGenerated } = await import('./formElement.gb');
    return await buildDotNetFormElementGenerated(jsObject);
}
