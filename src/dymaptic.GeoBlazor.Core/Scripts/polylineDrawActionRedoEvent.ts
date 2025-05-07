// override generated code in this file
import PolylineDrawActionRedoEventGenerated from './polylineDrawActionRedoEvent.gb';
import PolylineDrawActionRedoEvent = __esri.PolylineDrawActionRedoEvent;

export default class PolylineDrawActionRedoEventWrapper extends PolylineDrawActionRedoEventGenerated {

    constructor(component: PolylineDrawActionRedoEvent) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawActionRedoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionRedoEventGenerated } = await import('./polylineDrawActionRedoEvent.gb');
    return await buildJsPolylineDrawActionRedoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawActionRedoEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolylineDrawActionRedoEventGenerated } = await import('./polylineDrawActionRedoEvent.gb');
    return await buildDotNetPolylineDrawActionRedoEventGenerated(jsObject);
}
