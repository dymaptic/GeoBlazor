// override generated code in this file
import PolylineDrawActionCursorUpdateEventGenerated from './polylineDrawActionCursorUpdateEvent.gb';
import PolylineDrawActionCursorUpdateEvent = __esri.PolylineDrawActionCursorUpdateEvent;

export default class PolylineDrawActionCursorUpdateEventWrapper extends PolylineDrawActionCursorUpdateEventGenerated {

    constructor(component: PolylineDrawActionCursorUpdateEvent) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawActionCursorUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionCursorUpdateEventGenerated } = await import('./polylineDrawActionCursorUpdateEvent.gb');
    return await buildJsPolylineDrawActionCursorUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawActionCursorUpdateEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolylineDrawActionCursorUpdateEventGenerated } = await import('./polylineDrawActionCursorUpdateEvent.gb');
    return await buildDotNetPolylineDrawActionCursorUpdateEventGenerated(jsObject);
}
