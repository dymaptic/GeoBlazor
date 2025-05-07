// override generated code in this file
import ViewPointerLeaveEventGenerated from './viewPointerLeaveEvent.gb';
import ViewPointerLeaveEvent = __esri.ViewPointerLeaveEvent;

export default class ViewPointerLeaveEventWrapper extends ViewPointerLeaveEventGenerated {

    constructor(component: ViewPointerLeaveEvent) {
        super(component);
    }
    
}

export async function buildJsViewPointerLeaveEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewPointerLeaveEventGenerated } = await import('./viewPointerLeaveEvent.gb');
    return await buildJsViewPointerLeaveEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewPointerLeaveEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewPointerLeaveEventGenerated } = await import('./viewPointerLeaveEvent.gb');
    return await buildDotNetViewPointerLeaveEventGenerated(jsObject);
}
