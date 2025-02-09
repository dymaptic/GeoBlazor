// override generated code in this file
import UniqueValueInfoGenerated from './uniqueValueInfo.gb';
import UniqueValueInfo from '@arcgis/core/renderers/support/UniqueValueInfo';

export default class UniqueValueInfoWrapper extends UniqueValueInfoGenerated {

    constructor(component: UniqueValueInfo) {
        super(component);
    }
    
}              
export async function buildJsUniqueValueInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildJsUniqueValueInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUniqueValueInfo(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueInfoGenerated } = await import('./uniqueValueInfo.gb');
    return await buildDotNetUniqueValueInfoGenerated(jsObject);
}
