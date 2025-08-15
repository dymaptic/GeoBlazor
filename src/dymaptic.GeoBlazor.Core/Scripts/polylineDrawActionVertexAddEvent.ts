// override generated code in this file
import PolylineDrawActionVertexAddEventGenerated from './polylineDrawActionVertexAddEvent.gb';
import PolylineDrawActionVertexAddEvent = __esri.PolylineDrawActionVertexAddEvent;

export default class PolylineDrawActionVertexAddEventWrapper extends PolylineDrawActionVertexAddEventGenerated {

    constructor(component: PolylineDrawActionVertexAddEvent) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawActionVertexAddEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionVertexAddEventGenerated } = await import('./polylineDrawActionVertexAddEvent.gb');
    return await buildJsPolylineDrawActionVertexAddEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawActionVertexAddEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPolylineDrawActionVertexAddEventGenerated } = await import('./polylineDrawActionVertexAddEvent.gb');
    return await buildDotNetPolylineDrawActionVertexAddEventGenerated(jsObject, viewId);
}
