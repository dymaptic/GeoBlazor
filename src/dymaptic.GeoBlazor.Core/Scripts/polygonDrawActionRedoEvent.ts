// override generated code in this file
import PolygonDrawActionRedoEventGenerated from './polygonDrawActionRedoEvent.gb';
import PolygonDrawActionRedoEvent = __esri.PolygonDrawActionRedoEvent;

export default class PolygonDrawActionRedoEventWrapper extends PolygonDrawActionRedoEventGenerated {

    constructor(component: PolygonDrawActionRedoEvent) {
        super(component);
    }
    
}

export async function buildJsPolygonDrawActionRedoEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPolygonDrawActionRedoEventGenerated } = await import('./polygonDrawActionRedoEvent.gb');
    return await buildJsPolygonDrawActionRedoEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPolygonDrawActionRedoEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPolygonDrawActionRedoEventGenerated } = await import('./polygonDrawActionRedoEvent.gb');
    return await buildDotNetPolygonDrawActionRedoEventGenerated(jsObject, viewId);
}
