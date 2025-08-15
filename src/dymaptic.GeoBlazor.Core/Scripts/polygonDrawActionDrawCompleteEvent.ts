// override generated code in this file
import PolygonDrawActionDrawCompleteEventGenerated from './polygonDrawActionDrawCompleteEvent.gb';
import PolygonDrawActionDrawCompleteEvent = __esri.PolygonDrawActionDrawCompleteEvent;

export default class PolygonDrawActionDrawCompleteEventWrapper extends PolygonDrawActionDrawCompleteEventGenerated {

    constructor(component: PolygonDrawActionDrawCompleteEvent) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawActionDrawCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionDrawCompleteEventGenerated } = await import('./polygonDrawActionDrawCompleteEvent.gb');
    return await buildJsPolygonDrawActionDrawCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawActionDrawCompleteEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPolygonDrawActionDrawCompleteEventGenerated } = await import('./polygonDrawActionDrawCompleteEvent.gb');
    return await buildDotNetPolygonDrawActionDrawCompleteEventGenerated(jsObject, viewId);
}
