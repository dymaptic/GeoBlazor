// override generated code in this file
import UniqueValueClassGenerated from './uniqueValueClass.gb';
import UniqueValueClass from '@arcgis/core/renderers/support/UniqueValueClass';

export default class UniqueValueClassWrapper extends UniqueValueClassGenerated {

    constructor(component: UniqueValueClass) {
        super(component);
    }
    
}              
export async function buildJsUniqueValueClass(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildJsUniqueValueClassGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUniqueValueClass(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueClassGenerated } = await import('./uniqueValueClass.gb');
    return await buildDotNetUniqueValueClassGenerated(jsObject);
}
