// override generated code in this file
import FieldGenerated from './field.gb';
import Field from '@arcgis/core/layers/support/Field';

export default class FieldWrapper extends FieldGenerated {

    constructor(component: Field) {
        super(component);
    }
    
}              
export async function buildJsField(dotNetObject: any): Promise<any> {
    let { buildJsFieldGenerated } = await import('./field.gb');
    return await buildJsFieldGenerated(dotNetObject);
}
export async function buildDotNetField(jsObject: any): Promise<any> {
    let { buildDotNetFieldGenerated } = await import('./field.gb');
    return await buildDotNetFieldGenerated(jsObject);
}
