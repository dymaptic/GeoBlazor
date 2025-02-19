// override generated code in this file
import UniqueValuesGenerated from './uniqueValues.gb';
import uniqueValues from '@arcgis/core/smartMapping/statistics/uniqueValues';

export default class UniqueValuesWrapper extends UniqueValuesGenerated {

    constructor(component: uniqueValues) {
        super(component);
    }
    
}

export async function buildJsUniqueValues(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValuesGenerated } = await import('./uniqueValues.gb');
    return await buildJsUniqueValuesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValues(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValuesGenerated } = await import('./uniqueValues.gb');
    return await buildDotNetUniqueValuesGenerated(jsObject);
}
