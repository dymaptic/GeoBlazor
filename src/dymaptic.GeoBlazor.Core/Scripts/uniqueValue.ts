// override generated code in this file
import UniqueValueGenerated from './uniqueValue.gb';
import UniqueValue from '@arcgis/core/renderers/support/UniqueValue';

export default class UniqueValueWrapper extends UniqueValueGenerated {

    constructor(component: UniqueValue) {
        super(component);
    }
    
}              
export async function buildJsUniqueValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueGenerated } = await import('./uniqueValue.gb');
    return await buildJsUniqueValueGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUniqueValue(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueGenerated } = await import('./uniqueValue.gb');
    return await buildDotNetUniqueValueGenerated(jsObject);
}
