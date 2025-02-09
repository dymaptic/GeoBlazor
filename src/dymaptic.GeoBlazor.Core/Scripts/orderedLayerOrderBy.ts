// override generated code in this file
import OrderedLayerOrderByGenerated from './orderedLayerOrderBy.gb';
import OrderedLayerOrderBy = __esri.OrderedLayerOrderBy;

export default class OrderedLayerOrderByWrapper extends OrderedLayerOrderByGenerated {

    constructor(component: OrderedLayerOrderBy) {
        super(component);
    }
    
}              
export async function buildJsOrderedLayerOrderBy(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrderedLayerOrderByGenerated } = await import('./orderedLayerOrderBy.gb');
    return await buildJsOrderedLayerOrderByGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetOrderedLayerOrderBy(jsObject: any): Promise<any> {
    let { buildDotNetOrderedLayerOrderByGenerated } = await import('./orderedLayerOrderBy.gb');
    return await buildDotNetOrderedLayerOrderByGenerated(jsObject);
}
