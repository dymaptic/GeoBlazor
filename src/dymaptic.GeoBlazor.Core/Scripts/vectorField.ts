// override generated code in this file
import VectorFieldGenerated from './vectorField.gb';
import vectorField = __esri.vectorField;

export default class VectorFieldWrapper extends VectorFieldGenerated {

    constructor(component: vectorField) {
        super(component);
    }
    
}

export async function buildJsVectorField(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorFieldGenerated } = await import('./vectorField.gb');
    return await buildJsVectorFieldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorField(jsObject: any): Promise<any> {
    let { buildDotNetVectorFieldGenerated } = await import('./vectorField.gb');
    return await buildDotNetVectorFieldGenerated(jsObject);
}
