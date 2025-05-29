// override generated code in this file
import PolylineDrawActionUndoEventGenerated from './polylineDrawActionUndoEvent.gb';
import PolylineDrawActionUndoEvent = __esri.PolylineDrawActionUndoEvent;

export default class PolylineDrawActionUndoEventWrapper extends PolylineDrawActionUndoEventGenerated {

    constructor(component: PolylineDrawActionUndoEvent) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawActionUndoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionUndoEventGenerated } = await import('./polylineDrawActionUndoEvent.gb');
    return await buildJsPolylineDrawActionUndoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawActionUndoEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolylineDrawActionUndoEventGenerated } = await import('./polylineDrawActionUndoEvent.gb');
    return await buildDotNetPolylineDrawActionUndoEventGenerated(jsObject);
}
