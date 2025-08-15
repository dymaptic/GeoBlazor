// override generated code in this file
import PointDrawActionDrawCompleteEventGenerated from './pointDrawActionDrawCompleteEvent.gb';
import PointDrawActionDrawCompleteEvent = __esri.PointDrawActionDrawCompleteEvent;

export default class PointDrawActionDrawCompleteEventWrapper extends PointDrawActionDrawCompleteEventGenerated {

    constructor(component: PointDrawActionDrawCompleteEvent) {
        super(component);
    }
    
}

export async function buildJsPointDrawActionDrawCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointDrawActionDrawCompleteEventGenerated } = await import('./pointDrawActionDrawCompleteEvent.gb');
    return await buildJsPointDrawActionDrawCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointDrawActionDrawCompleteEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointDrawActionDrawCompleteEventGenerated } = await import('./pointDrawActionDrawCompleteEvent.gb');
    return await buildDotNetPointDrawActionDrawCompleteEventGenerated(jsObject, viewId);
}
