// override generated code in this file
import PointDrawActionCursorUpdateEventGenerated from './pointDrawActionCursorUpdateEvent.gb';
import PointDrawActionCursorUpdateEvent = __esri.PointDrawActionCursorUpdateEvent;

export default class PointDrawActionCursorUpdateEventWrapper extends PointDrawActionCursorUpdateEventGenerated {

    constructor(component: PointDrawActionCursorUpdateEvent) {
        super(component);
    }
    
}

export async function buildJsPointDrawActionCursorUpdateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointDrawActionCursorUpdateEventGenerated } = await import('./pointDrawActionCursorUpdateEvent.gb');
    return await buildJsPointDrawActionCursorUpdateEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointDrawActionCursorUpdateEvent(jsObject: any): Promise<any> {
    let { buildDotNetPointDrawActionCursorUpdateEventGenerated } = await import('./pointDrawActionCursorUpdateEvent.gb');
    return await buildDotNetPointDrawActionCursorUpdateEventGenerated(jsObject);
}
