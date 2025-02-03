// override generated code in this file
import UniqueValueInfoGenerated from './uniqueValueInfo.gb';
import UniqueValueInfo from '@arcgis/core/renderers/support/UniqueValueInfo';

export default class UniqueValueInfoWrapper extends UniqueValueInfoGenerated {

    constructor(component: UniqueValueInfo) {
        super(component);
    }
    
}              
export async function buildJsUniqueValueInfo(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildJsUniqueValueInfoGenerated(dotNetObject);
}
export async function buildDotNetUniqueValueInfo(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildDotNetUniqueValueInfoGenerated(jsObject);
}
