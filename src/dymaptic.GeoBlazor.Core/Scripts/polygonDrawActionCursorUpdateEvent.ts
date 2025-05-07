// override generated code in this file
import PolygonDrawActionCursorUpdateEventGenerated from './polygonDrawActionCursorUpdateEvent.gb';
import PolygonDrawActionCursorUpdateEvent = __esri.PolygonDrawActionCursorUpdateEvent;

export default class PolygonDrawActionCursorUpdateEventWrapper extends PolygonDrawActionCursorUpdateEventGenerated {

    constructor(component: PolygonDrawActionCursorUpdateEvent) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawActionCursorUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionCursorUpdateEventGenerated } = await import('./polygonDrawActionCursorUpdateEvent.gb');
    return await buildJsPolygonDrawActionCursorUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawActionCursorUpdateEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolygonDrawActionCursorUpdateEventGenerated } = await import('./polygonDrawActionCursorUpdateEvent.gb');
    return await buildDotNetPolygonDrawActionCursorUpdateEventGenerated(jsObject);
}
