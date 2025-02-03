// override generated code in this file
import UniqueValueGroupGenerated from './uniqueValueGroup.gb';
import UniqueValueGroup from '@arcgis/core/renderers/support/UniqueValueGroup';

export default class UniqueValueGroupWrapper extends UniqueValueGroupGenerated {

    constructor(component: UniqueValueGroup) {
        super(component);
    }
    
}              
export async function buildJsUniqueValueGroup(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildJsUniqueValueGroupGenerated(dotNetObject);
}
export async function buildDotNetUniqueValueGroup(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueGroupGenerated } = await import('./uniqueValueGroup.gb');
    return await buildDotNetUniqueValueGroupGenerated(jsObject);
}
