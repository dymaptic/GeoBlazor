// override generated code in this file
import PolygonDrawActionVertexRemoveEventGenerated from './polygonDrawActionVertexRemoveEvent.gb';
import PolygonDrawActionVertexRemoveEvent = __esri.PolygonDrawActionVertexRemoveEvent;

export default class PolygonDrawActionVertexRemoveEventWrapper extends PolygonDrawActionVertexRemoveEventGenerated {

    constructor(component: PolygonDrawActionVertexRemoveEvent) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawActionVertexRemoveEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionVertexRemoveEventGenerated } = await import('./polygonDrawActionVertexRemoveEvent.gb');
    return await buildJsPolygonDrawActionVertexRemoveEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawActionVertexRemoveEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolygonDrawActionVertexRemoveEventGenerated } = await import('./polygonDrawActionVertexRemoveEvent.gb');
    return await buildDotNetPolygonDrawActionVertexRemoveEventGenerated(jsObject);
}
