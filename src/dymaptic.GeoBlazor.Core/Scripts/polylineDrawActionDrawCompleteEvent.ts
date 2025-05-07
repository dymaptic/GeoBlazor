// override generated code in this file
import PolylineDrawActionDrawCompleteEventGenerated from './polylineDrawActionDrawCompleteEvent.gb';
import PolylineDrawActionDrawCompleteEvent = __esri.PolylineDrawActionDrawCompleteEvent;

export default class PolylineDrawActionDrawCompleteEventWrapper extends PolylineDrawActionDrawCompleteEventGenerated {

    constructor(component: PolylineDrawActionDrawCompleteEvent) {
        super(component);
    }
    
}

export async function buildJsPolylineDrawActionDrawCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolylineDrawActionDrawCompleteEventGenerated } = await import('./polylineDrawActionDrawCompleteEvent.gb');
    return await buildJsPolylineDrawActionDrawCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolylineDrawActionDrawCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetPolylineDrawActionDrawCompleteEventGenerated } = await import('./polylineDrawActionDrawCompleteEvent.gb');
    return await buildDotNetPolylineDrawActionDrawCompleteEventGenerated(jsObject);
}
