// override generated code in this file
import PolygonDrawActionVertexAddEventGenerated from './polygonDrawActionVertexAddEvent.gb';
import PolygonDrawActionVertexAddEvent = __esri.PolygonDrawActionVertexAddEvent;

export default class PolygonDrawActionVertexAddEventWrapper extends PolygonDrawActionVertexAddEventGenerated {

    constructor(component: PolygonDrawActionVertexAddEvent) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawActionVertexAddEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionVertexAddEventGenerated } = await import('./polygonDrawActionVertexAddEvent.gb');
    return await buildJsPolygonDrawActionVertexAddEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawActionVertexAddEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPolygonDrawActionVertexAddEventGenerated } = await import('./polygonDrawActionVertexAddEvent.gb');
    return await buildDotNetPolygonDrawActionVertexAddEventGenerated(jsObject, viewId);
}
