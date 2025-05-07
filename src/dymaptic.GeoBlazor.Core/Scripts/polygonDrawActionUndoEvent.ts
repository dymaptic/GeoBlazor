// override generated code in this file
import PolygonDrawActionUndoEventGenerated from './polygonDrawActionUndoEvent.gb';
import PolygonDrawActionUndoEvent = __esri.PolygonDrawActionUndoEvent;

export default class PolygonDrawActionUndoEventWrapper extends PolygonDrawActionUndoEventGenerated {

    constructor(component: PolygonDrawActionUndoEvent) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawActionUndoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionUndoEventGenerated } = await import('./polygonDrawActionUndoEvent.gb');
    return await buildJsPolygonDrawActionUndoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawActionUndoEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolygonDrawActionUndoEventGenerated } = await import('./polygonDrawActionUndoEvent.gb');
    return await buildDotNetPolygonDrawActionUndoEventGenerated(jsObject);
}
