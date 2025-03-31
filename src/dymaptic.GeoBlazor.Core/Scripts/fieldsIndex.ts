// override generated code in this file
import FieldsIndexGenerated from './fieldsIndex.gb';
import FieldsIndex from '@arcgis/core/layers/support/FieldsIndex';

export default class FieldsIndexWrapper extends FieldsIndexGenerated {

    constructor(component: FieldsIndex) {
        super(component);
    }

}

export async function buildJsFieldsIndex(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFieldsIndexGenerated} = await import('./fieldsIndex.gb');
    return await buildJsFieldsIndexGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFieldsIndex(jsObject: any): Promise<any> {
    let {buildDotNetFieldsIndexGenerated} = await import('./fieldsIndex.gb');
    return await buildDotNetFieldsIndexGenerated(jsObject);
}
