// override generated code in this file
import PolylineBarrierGenerated from './polylineBarrier.gb';
import PolylineBarrier from '@arcgis/core/rest/support/PolylineBarrier';

export default class PolylineBarrierWrapper extends PolylineBarrierGenerated {

    constructor(component: PolylineBarrier) {
        super(component);
    }
    
}

export async function buildJsPolylineBarrier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineBarrierGenerated } = await import('./polylineBarrier.gb');
    return await buildJsPolylineBarrierGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineBarrier(jsObject: any): Promise<any> {
    let { buildDotNetPolylineBarrierGenerated } = await import('./polylineBarrier.gb');
    return await buildDotNetPolylineBarrierGenerated(jsObject);
}
