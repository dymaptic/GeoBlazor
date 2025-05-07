// override generated code in this file
import PolylineDrawActionVertexRemoveEventGenerated from './polylineDrawActionVertexRemoveEvent.gb';
import PolylineDrawActionVertexRemoveEvent = __esri.PolylineDrawActionVertexRemoveEvent;

export default class PolylineDrawActionVertexRemoveEventWrapper extends PolylineDrawActionVertexRemoveEventGenerated {

    constructor(component: PolylineDrawActionVertexRemoveEvent) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawActionVertexRemoveEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionVertexRemoveEventGenerated } = await import('./polylineDrawActionVertexRemoveEvent.gb');
    return await buildJsPolylineDrawActionVertexRemoveEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawActionVertexRemoveEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolylineDrawActionVertexRemoveEventGenerated } = await import('./polylineDrawActionVertexRemoveEvent.gb');
    return await buildDotNetPolylineDrawActionVertexRemoveEventGenerated(jsObject);
}
