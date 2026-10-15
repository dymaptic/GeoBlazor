// override generated code in this file
import PolygonBarrierGenerated from './polygonBarrier.gb';
import PolygonBarrier from '@arcgis/core/rest/support/PolygonBarrier';

export default class PolygonBarrierWrapper extends PolygonBarrierGenerated {

    constructor(component: PolygonBarrier) {
        super(component);
    }
    
}

export async function buildJsPolygonBarrier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonBarrierGenerated } = await import('./polygonBarrier.gb');
    return await buildJsPolygonBarrierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonBarrier(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPolygonBarrierGenerated } = await import('./polygonBarrier.gb');
    return await buildDotNetPolygonBarrierGenerated(jsObject, layerId, viewId);
}
